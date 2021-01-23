    using System.Collections.Generic;
    using System.Web.Script.Serialization;
    namespace ConsoleApplication1
    {
        class Program
        {
            private static void Main(string[] args)
            {
                var person = new Person();
                person.Name = "reacher gilt";
                person.Address = "100 East Way";
                person.Age = 74; 
                person.Aliases = new List<string>(new []{"teddy", "freddy", "eddy", "Betty"});
                person.Bars = new Dictionary<string, List<BarClass>>();
                
                person.Bars.Add("items",
                    new List<BarClass>(new[]{ 
                    new BarClass("beep","boop"),
                    new BarClass("meep","moop"),
                    new BarClass("feep","foop"),
                }));
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string jsonString = serializer.Serialize(person);
                var rehydrated = serializer.Deserialize<Person>(jsonString);
            }
        }
     
        class BarClass
        { 
            public string Sub_Property1 { get; set; }
            public string Sub_Property2 { get; set; }
            public BarClass() { }
            public BarClass (string one, string two)
            {
                Sub_Property1 = one;
                Sub_Property2 = two;
            }
        }
        class Person
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public int Age { get; set; }
            public List<string> Aliases;
            public Dictionary <string, List<BarClass> >Bars { get; set; }
        }
    }
