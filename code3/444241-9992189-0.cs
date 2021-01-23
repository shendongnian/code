    using System.IO;
    using System.Xml.Serialization;
    using PDFCreation.Objects;
    
    public class Test
    {
        static void Main(string[] args)
        {
            XmlSerializer ser = new XmlSerializer(typeof(PdfFile2));
            PdfFile2 pdf = (PdfFile2)ser.Deserialize(File.OpenRead("test.xml"));
        }
    }
