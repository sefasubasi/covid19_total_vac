using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using System.Reflection;
using System.Collections.ObjectModel;

namespace ReadingDataFromCSV
{
    class Program
    {
        static void Main(string[] args)
        {

            ReadCSVFile();
            Console.ReadLine();
        }
        static void ReadCSVFile()
        {
            string address = "C:\\Users\\Sefa\\Desktop\\misson_5\\ConsoleApp1\\country_vaccination_stats.csv";//changeable
            var lines = File.ReadAllLines(address);
            var list = new List<Contact>();
            for (int i = 1; i < lines.Length; i++)
            {
                var values = lines[i].Split(',');
                if (values.Length == 4)
                {
                    var contact = new Contact() { Country = values[0], Date = Convert.ToDateTime(values[1], CultureInfo.InvariantCulture), Daily_vaccinations = (values[2] == "") ? 0 : Convert.ToInt32(values[2]), Vaccines = values[3] };
                    list.Add(contact);
                }
                else if (values.Length == 5)
                {
                    var contact = new Contact() { Country = values[0], Date = Convert.ToDateTime(values[1], CultureInfo.InvariantCulture), Daily_vaccinations = (values[2] == "") ? 0 : Convert.ToInt32(values[2]), Vaccines = values[3] + "," + values[4] };
                    list.Add(contact);
                }
                else if (values.Length == 6)
                {
                    var contact = new Contact() { Country = values[0], Date = Convert.ToDateTime(values[1], CultureInfo.InvariantCulture), Daily_vaccinations = (values[2] == "") ? 0 : Convert.ToInt32(values[2]), Vaccines = values[3] + "," + values[4] + "," + values[5] };
                    list.Add(contact);
                }
            }
            int counter = 0;
            foreach(var contact in list)
            {
                if((contact.Date.Month.ToString()+"/"+contact.Date.Day.ToString()+"/" + contact.Date.Year.ToString())  == "1/6/2021")
                {
                    counter++;
                    Console.WriteLine(contact.Country);
                }
            }
            Console.WriteLine("\n" + "Total Country =" + counter.ToString());



        }
        public class Contact
        {
            public string Country { get; set; }
            public DateTime Date { get; set; }
            public int Daily_vaccinations { get; set; }
            public string Vaccines { get; set; }

        }

       
    }
}
