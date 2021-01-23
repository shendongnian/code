    using System;
    using System.Collections.Generic;
    
    using System.Text;
    
    using System.Xml.Serialization;
    
    namespace Stackoverflow
    {
      
        public class Program
        {
          
            static void Main(string[] args)
            {
               
              var p = new Person
                {
                    FirstName = "Daniel",  /// in your case you get it from the form
                    LastName = "Endeg"
    
                };
    
                var x = new XmlSerializer(p.GetType());
                x.Serialize(Console.Out, p);
                Console.WriteLine();
                Console.ReadLine();
            }
        }
    
        public class Person
        {
            public string FirstName { get; set; }
    
            public string LastName { get; set; }
        }
    }
