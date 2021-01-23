    using System;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    
    using Shared;
    
    namespace Out
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Create the object.
                TestClass test = new TestClass();
                test.Test = "Monkey";
                test.TestAgain = "Hat";
                test.Cheese = "Fish";
    
                // Serialize it.
                XmlSerializer serializer = new XmlSerializer(typeof (TestClass));
                StringBuilder sb = new StringBuilder();
                using (var writer = new StringWriter(sb))
                    serializer.Serialize(writer, test);
               
                // And write it to console.
                Console.WriteLine(sb.ToString());
            }
        }
    }
