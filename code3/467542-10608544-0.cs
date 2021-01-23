    using System;
    using Newtonsoft.Json;
    namespace ConsoleApplication1
    {
        class Program
        {
            private static void Main(string[] args)
            {
                var bleah = new Person();
                var settings = new JsonSerializerSettings {  TypeNameHandling = TypeNameHandling.Objects };
                var output = JsonConvert.SerializeObject(bleah, settings);
                Console.WriteLine(output);
                var deserializeObject = JsonConvert.DeserializeObject(output, settings);
                Console.WriteLine(deserializeObject.GetType().Name);
            }
        }
        class Person
        {
            public string Name { get; set; }
        }
    }
