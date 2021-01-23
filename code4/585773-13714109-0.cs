    namespace Demo.Stackoverflow
    {
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using LinqToExcel;
    
        public class Person
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                LoadExcel();
                Console.ReadLine();
            }
    
            private static void LoadExcel()
            {
                var directorio = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Book.xls");
                var book = new ExcelQueryFactory(directorio);
    
                var rows = from c in book.WorksheetNoHeader()
                           select c;
                List<Person> people = new List<Person>();
    
                int i = 1;
                foreach (var row in rows)
                {
                    if (i % 2 == 0)
                    {
                        if (people.Count != 0 && people.Last().Age == 0)
                        {
                            people.Last().Age = Convert.ToInt32(row[0].Value.ToString());
                        }
                        else
                        {
                            Person per = new Person()
                            {
                                Name = row[0].Value.ToString(),
                                LastName = row[1].Value.ToString()
                            };
                            people.Add(per);
                        }
                    }
                    i++;
                }
            }
    	}
    }
