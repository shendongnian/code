    class Program
        {
            static void Main(string[] args)
            {
                string xml = "<KitContent>" +
                              "<MsiData>" +
                                "<FileName>file1</FileName>" +
                                "<BaseProductVersion>1.1.0.0</BaseProductVersion>" +
                              "</MsiData>" +
                              "<MsiData>" +
                                "<FileName>file2</FileName>" +
                                "<BaseProductVersion>1.1.0.0</BaseProductVersion>" +
                              "</MsiData>" +
                            "</KitContent>";
    
                XmlSerializer serializer = new XmlSerializer(typeof(KitContent));
                KitContent kitContent = (KitContent)serializer.Deserialize(XmlReader.Create(new StringReader(xml)));
    
                Console.WriteLine(kitContent.anyIdentifier[0].FileName);
                Console.WriteLine(kitContent.anyIdentifier[0].OtherName);
                Console.WriteLine(kitContent.anyIdentifier[1].FileName);
                Console.WriteLine(kitContent.anyIdentifier[1].OtherName);
            }
        }
    
        [XmlRoot("KitContent")]
        public class KitContent
        {
            [XmlElement("MsiData")]
            public List<MsiData> anyIdentifier { get; set; }
        }
    
        public class MsiData
        {
            public string FileName { get; set; }
    
            [XmlElement("BaseProductVersion")]
            public string OtherName { get; set; }
        }
