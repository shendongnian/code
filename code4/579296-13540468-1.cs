    class Program
    {
        static void Main(string[] args)
        {
            using (var stream = new MemoryStream())
            {
                var serializer = new XmlSerializer(typeof(Notes));
                var writer = new MyXmlTextWriter(stream);
                serializer.Serialize(writer, new Notes() { typeName = "Acknowledged by PPS", dataValue="" });
                var result = Encoding.UTF8.GetString(stream.ToArray());
                Console.WriteLine(result);
            }
           Console.ReadKey();
        }
