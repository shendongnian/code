    using System.IO;
    using System.Reflection;
    using System.Xml;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var stream =  Assembly.GetExecutingAssembly().GetManifestResourceStream("ConsoleApplication1.XMLFile1.xml");
                StreamReader reader = new StreamReader(stream);
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(reader.ReadToEnd());
            }
        }
    }
