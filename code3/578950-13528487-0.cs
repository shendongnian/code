    using System.IO;
    using System.Xml.Serialization;
    public class A
    {
        public B B { get; set; }
    }
    public class B
    {
        public int A {get;set;}
    }
    static class Program
    {
        static void Main()
        {
            var writer = new XmlSerializer(typeof(A));
            using (var file = File.Create(@"SerializationOverview.xml"))
            {
                writer.Serialize(file, new A { B = new B { A = 123 } });
            }
        }
    }
