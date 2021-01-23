    public class StackOverflow_10523009
    {
        public class MyClass : IXmlSerializable
        {
            public Complex[] ComplexNumbers;
            public XmlSchema GetSchema()
            {
                return null;
            }
            public void ReadXml(XmlReader reader)
            {
                reader.ReadStartElement("MyClass");
                List<Complex> numbers = new List<Complex>();
                while (reader.IsStartElement("Complex"))
                {
                    Complex c = new Complex(
                        double.Parse(reader.GetAttribute("Real")),
                        double.Parse(reader.GetAttribute("Imaginary")));
                    numbers.Add(c);
                    reader.Skip();
                }
                reader.ReadEndElement();
                this.ComplexNumbers = numbers.ToArray();
            }
            public void WriteXml(XmlWriter writer)
            {
                foreach (var complex in ComplexNumbers)
                {
                    writer.WriteStartElement("Complex");
                    writer.WriteStartAttribute("Real"); writer.WriteValue(complex.Real); writer.WriteEndAttribute();
                    writer.WriteStartAttribute("Imaginary"); writer.WriteValue(complex.Imaginary); writer.WriteEndAttribute();
                    writer.WriteEndElement();
                }
            }
            public override string ToString()
            {
                return "MyClass[" + string.Join(",", ComplexNumbers) + "]";
            }
        }
        public static void Test()
        {
            MyClass mc = new MyClass { ComplexNumbers = new Complex[] { new Complex(3, 4), new Complex(0, 1), new Complex(1, 0) } };
            XmlSerializer xs = new XmlSerializer(typeof(MyClass));
            MemoryStream ms = new MemoryStream();
            xs.Serialize(ms, mc);
            Console.WriteLine(Encoding.UTF8.GetString(ms.ToArray()));
            ms.Position = 0;
            MyClass mc2 = (MyClass)xs.Deserialize(ms);
            Console.WriteLine(mc2);
        }
    }
