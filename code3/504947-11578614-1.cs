    class Program
    {
        static void Main()
        {
            var serializer = new XmlSerializer(typeof(xml));
            using (var reader = XmlReader.Create("test.xml"))
            {
                var result = (xml)serializer.Deserialize(reader);
            }
        }
    }
