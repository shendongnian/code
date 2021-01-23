    public class XmlTool
    {
        public static string filepath = @"C:\\This\That\Folder";
        private static XmlReader reader;
        private static XmlWriter writer;
        public static void Write2Xml(string s)
        {
            writer = XmlWriter.Create(filepath);
            /* Do Stuff */
            writer.Close( );
        }
        public static string ReadFromXml( )
        {
            reader = XmlReader.Create(filepath);
            /* Do Stuff */
            reader.Close( );
        }
    }
