    using (FileStream f = new FileStream(@"D:\a.xml", FileMode.OpenOrCreate, FileAccess.Write))
    {
        f.Seek(-("</DocumentElement>\n".Length), SeekOrigin.End);
        using (XmlTextWriter x = new XmlTextWriter(f, Encoding.UTF8))
        {
            x.WriteStartElement("Another");
            x.WriteAttributeString("attr", "value");
            x.WriteEndElement();
            // Close the file with a new terminating end-element
            x.WriteRaw("\r\n</DocumentElement>\r\n");
        }
    }
