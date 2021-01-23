    using System;
    using System.IO;
    using System.Numerics;
    using System.Xml.Serialization;
    public class Test {
        public static void Main() {
            var c = new Complex(1, 2);
            XmlSerializer s = new XmlSerializer(typeof(Complex));
            StringWriter sw = new StringWriter();
            s.Serialize(sw, c);
            Console.WriteLine(sw.ToString());
        }
    }
