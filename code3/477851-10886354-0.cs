    public class SomeType
    {
        public string Foo { get; set; }
        public string Bar { get { Console.WriteLine("get_Bar"); return "abc"; } }
    
        static void Main()
        {
            var ser = new XmlSerializer(typeof (SomeType));
            ser.Serialize(Console.Out, new SomeType { Foo = "def" });
        }
    }
