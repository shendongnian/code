    public class Test
    {
        private static void Main()
        {
            var ser = new XmlSerializer(typeof (Test));
            var obj = new Test {Value = "abc"};
            ser.Serialize(Console.Out, obj);
            obj = new Test { Value = 123 };
            ser.Serialize(Console.Out, obj);
            obj = new Test { Value = 456.7F };
            ser.Serialize(Console.Out, obj);
        }
    
        [XmlElement("a", Type = typeof(int))]
        [XmlElement("b", Type = typeof(string))]
        [XmlElement("c", Type = typeof(float))]
        public object Value { get; set; }
    }
