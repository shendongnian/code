    using System;
    using System.IO;
    using System.Xml.Serialization;
    
    using Shared;
    
    namespace In
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Read the input XML; until complete.
                string input = Console.In.ReadToEnd();
    
                TestClass passedIn;
    
                // Deserialize it.
                var serializer = new XmlSerializer(typeof (TestClass));
                using (var reader = new StringReader(input))
                    passedIn = (TestClass) serializer.Deserialize(reader);
    
                // Do something with the object.
                Console.WriteLine("Test:      {0}", passedIn.Test);
                Console.WriteLine("TestAgain: {0}", passedIn.TestAgain);
                Console.WriteLine("Cheese:    {0}", passedIn.Cheese);
            }
        }
    }
