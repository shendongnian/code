    var sb = new StringBuilder(); 
    var settings = new XmlWriterSettings();
    //..settings
    using (var writer = XmlWriter.Create(sb, settings))
    {
        //...
    }
    var encoding = new ASCIIEncoding();
    string s = Convert.ToBase64String(encoding.GetBytes(sb.ToString()));
    File.WriteAllText("c:\temp.txt", s);
