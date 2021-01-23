    using (FileStream f = new FileStream(@"D:\a.xml", FileMode.OpenOrCreate, FileAccess.Write))
    {
        f.Seek(-("</DocumentElement>\n".Length), SeekOrigin.End);
        using (XmlTextWriter x = new XmlTextWriter(f, Encoding.UTF8))
        {
            x.WriteStartElement("Another");
            x.WriteAttributeString("attr", "value");
            x.WriteEndElement();
            // Make sure all the XML has been flushed to the stream
            x.Flush();
            // Close the file with a new terminating end-element
            byte[] rawdata = Encoding.UTF8.GetBytes("\r\n</DocumentElement>\r\n");
            f.Write(rawdata, 0, rawdata.Length);
        }
    }
