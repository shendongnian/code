    using System.Xml.Serialization;
    using Newtonsoft.Json;
    
    namespace SoTestConsole
    {
        [XmlInclude(typeof(TestClassLibrary.Class1))]
        [XmlInclude(typeof(TestClassLibrary1.Class1))]
        public class SuperInfo
        {
            public TestClassLibrary.Class1 A { get; set; }
            public TestClassLibrary1.Class1 B { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var obj = new SuperInfo()
                {
                    A = new TestClassLibrary.Class1() { MyProperty = "test1" },
                    B = new TestClassLibrary1.Class1() { MyProperty = "test2" }
                };
    
                // Error case
                //XmlSerializer xmlSerializer = new XmlSerializer(typeof(SuperInfo));
                
                // but below will work 
                var json = JsonConvert.SerializeObject(obj);
                var xDoc = JsonConvert.DeserializeXNode(json, "SuperInfo");
    
            }
        }
    }
