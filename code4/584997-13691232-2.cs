    XmlDocument xdoc = new XmlDocument();
    using (SqlCommand command = new SqlCommand(queryString, connection))
    {
        XmlReader reader = command.ExecuteXmlReader();
        if (reader.Read())
        {
            xdoc.Load(reader);
        }
    }
        
       
