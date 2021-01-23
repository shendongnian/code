    var stream = new StreamReader("Input.txt");
    string watts = null;
    using (var reader = new XmlTextReader(stream))
    {
        while (reader.Read())
        {
            if (reader.IsStartElement("watts"))
            {
                reader.Read();
                watts = reader.Value;
                break;
            }
        }
    }
