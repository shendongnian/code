    using System;
    using System.IO;
    using Newtonsoft.Json;
    
    namespace JsonNetNullablePropertyTest
    {
        class Program
        {
            static void Main()
            {
                var myPerson = new Person {
                    Dob = null,
                    FirstName = "Adrian",
                    Id = 1,
                    LastName = "Bobby"
                };
    
                using (var textWriter = new StringWriter())
                using (var writer = new JsonTextWriter(textWriter))
                {
                    // Create the serializer.
                    var serializer = new JsonSerializer();
    
                    // Serialize.
                    serializer.Serialize(writer, myPerson);
    
                    // Write the output.
                    Console.WriteLine(textWriter);
                }
            }
        }
    
        public class Person
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
    
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Include,
                NullValueHandling = NullValueHandling.Include)]
            public DateTime? Dob { get; set; }
        }
    }
