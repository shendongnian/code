    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace StackOverflow
    {
        interface IPrintable
        {
            string Name { get; }
        }
    
        class City : IPrintable
        {
            public string Name { get; set; }
        }
    
        class Country : IPrintable
        {
            public string Name { get; set; }
            public City MyCity { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var myCountry = new Country()
                {
                    Name = "Ukraine",
                    MyCity = new City()
                     {
                         Name = "Kharkov"
                     }
                };
    
                Console.WriteLine(Print(myCountry, @"{{{0}}}"));
                Console.WriteLine(Print(new City()
                {
                    Name = "New-York"
                }, @"{{{0}}}"));
            }
    
            private static string Print(IPrintable printaleObject, string formatter)
            {
                foreach (var prop in printaleObject.GetType().GetProperties())
                {
                    object val = prop.GetValue(printaleObject, null);
                    if (val is IPrintable)
                    {
                        return String.Format(formatter, printaleObject.Name) + Print((IPrintable)val, formatter);
                    }
                }
                return String.Format(formatter, printaleObject.Name);
            }
        }
    }
