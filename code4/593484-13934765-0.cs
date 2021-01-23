    [Test]
    public void XmlReaderTest()
    {
        using (Stream stream = new MemoryStream(Encoding.UTF8.GetBytes(Properties.Resources.TestXml)))
        {
            using (XmlReader reader = XmlReader.Create(stream))
            {
                reader.MoveToContent();
                string readElementString = reader.ReadInnerXml();
                //Do someething
            }
            stream.Position = 0;
            using (XmlReader reader = XmlReader.Create(stream))
            {
                reader.MoveToContent();
                string readElementString = reader.ReadInnerXml();
                //Do someething
            }
        }
    }
