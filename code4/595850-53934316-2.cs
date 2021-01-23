    var stream1 = new MemoryStream(Encoding.UTF8.GetBytes(input1));
    var stream2 = new MemoryStream(Encoding.UTF8.GetBytes(input2));
    stream1.Position = 0;
    stream2.Position = 0;
    var position1 = DoWork(stream1, new Position());
    var position2 = DoWork(stream2, position1);
        public static Position DoWork(Stream stream, Position position)
        {
            using (XmlTextReader xmlTextReader = new XmlTextReader(stream))
            {
                using (XmlReader xmlReader = XmlReader.Create(xmlTextReader, xmlReaderSettings))
                {
                    // restores the last position 
                    xmlTextReader.SetPosition(position);
                    System.Diagnostics.Debug.WriteLine(xmlReader.Value); // Second time prints 99999999
                    while (xmlReader.Value != "NOT_READY" && xmlReader.Read())
                    {
                        // a custom logic to process nodes....
                    }
                    // saves the position to process later ...
                    position = xmlTextReader.GetPosition();
                    System.Diagnostics.Debug.WriteLine(xmlReader.Value); // First time prints NOT_READY
                }
            }
            return position;
        }
    }
    public class Position
    {
        public int LinePosition { get; set; }
        public int LineNumber { get; set; }
    }
    public static class XmlReaderExtensions
    {
        public static void SetPosition(this XmlTextReader xmlTextReader, Position position)
        {
            if (position != null)
            {
                while (xmlTextReader.LineNumber < position.LineNumber && xmlTextReader.Read())
                {
                }
                while (xmlTextReader.LinePosition < position.LinePosition && xmlTextReader.Read())
                {
                }
            }
        }
        public static Position GetPosition(this XmlTextReader xmlTextReader)
        {
            Position output;
            if (xmlTextReader.EOF)
            {
                output = new Position();
            }
            else
            {
                output = new Position { LineNumber = xmlTextReader.LineNumber, LinePosition = xmlTextReader.LinePosition };
            }
            return output;
        }
    }
