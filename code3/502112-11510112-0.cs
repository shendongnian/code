    using(XmlReader reader = XmlReader.Create("..."))
    {
        while (reader.Read())
        {
            if (reader.IsStartElement())
            {
                switch (reader.Name)
                {
                    case "CategoryList":
                        var cat = reader.ReadElementContentAsString();
                        break;
                    case "ContactEmail":
                        var email = reader.ReadElementContentAsString();
                        break;
                }
            }
        }
    }
