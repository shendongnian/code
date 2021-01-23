    using (Stream stream = File.Open(SerializeXmlFileName, FileMode.Create))
    {
        using (TextWriter writer = new StreamWriter(stream, Encoding.UTF8))
        {
             XmlSerializer xmlFormatter = new XmlSerializer(this.Member.GetType());
             xmlFormatter.Serialize(writer, this.Member);
             writer.Close();
        }
        stream.Close();
    }
