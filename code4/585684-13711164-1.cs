    namespace Demo.Stackoverflow
    {
        using System.Data;
        using System.Data.Common;
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
                ReadXML();
                Console.ReadLine();
            }
            private static void ReadXML()
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\Resources\\File.xml";
                XDocument doc = XDocument.Load(path);
    
                var People = (from people in doc.Descendants("Person")
                                select new Person()
                                {
                                    Name = null != people.Descendants("Name").FirstOrDefault() ?
                                             people.Descendants("Name").First().Value : string.Empty,
    
                                    LastName = null != people.Descendants("LastName").FirstOrDefault() ?
                                             people.Descendants("LastName").First().Value : string.Empty,
    
                                    Age = null != people.Descendants("Age").FirstOrDefault() ?
                                             Convert.ToInt32(people.Descendants("Age").First().Value) : 0
                                }).ToList();
            }
        }
    }
