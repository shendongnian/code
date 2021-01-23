    XmlTextReader reader = new XmlTextReader(strURL);
        while (reader.Read())
        {
            switch(reader.Name)
             {
                case "ContactEmail":
                      //reader.ReadElementContentAsString();
                  break;
                 //...
             }
        }
