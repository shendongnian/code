    public void Write_File(rss r, string fileName)//-- rss here is a class I built in other place
    {
        XmlSerializer serializer = new XmlSerializer(typeof(rss));
        TextWriter textWriter = new StreamWriter(path + fileName);
        serializer.Serialize(textWriter, HttpUtility.HtmlEncode(r));
        textWriter.Close();            
    }
