    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication4 {
        public class Customer {
            public string Country { get; set; }
            public string Status { get; set; }
        }
    
        class Program {
            static void Main(string[] args) {
                var list = new List<Customer>();
                list.Add(new Customer() { Country = "India", Status = "A" });
                list.Add(new Customer() { Country = "USA", Status = "A" });
    
                var results = list.Where((c) => c.Country == "India" && c.Status == "A");
    
                if (results.Any()) {
                    Console.WriteLine(results.First().Country);
                }
                Console.ReadLine();
            }
        }
    }
