    internal static class Extensions {
        public static void SerializeToXml<T>(this T myobj)
            {
                XmlSerializer myserializer = new XmlSerializer(typeof(T));
                TextWriter mywriter = new StreamWriter("C:\\my.xml");
                myserializer.Serialize(mywriter, myobj);
                mywriter.Close();
            }
    }
