    using System.IO;
    using System.Numerics;
    using System.Runtime.Serialization.Formatters.Soap;
    public class Test {
        public static void Main() {
            var c = new Complex(1, 2);
            Stream stream = File.Open("data.xml", FileMode.Create);
            SoapFormatter formatter = new SoapFormatter();
            formatter.Serialize(stream, c);
            stream.Close();
        }
    }
