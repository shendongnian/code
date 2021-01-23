    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApplication14
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Example> list = new List<Example>()
                {
                    new Example() { Name = "John Doe" },
                    new Example() { Name = "Jane Doe" },
                    new Example() { Name = "Fred Doe" },
                };
    
                string s = list.Select(item => item.Name)
                               .Aggregate((accumulator, iterator) => accumulator += "," + iterator);
            }
        }
    
        public class Example
        {
            public string Name { get; set; }
        }
    }
