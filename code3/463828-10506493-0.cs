        while (reader.Read())
        {
            switch (reader.NodeType)
            {
                case XmlNodeType.Element:
                    if (reader.GetAttribute("name") == stock)
                    {
                        if (reader.Read() && reader.NodeType == XmlNodeType.Text)
                        {
                            stockText = reader.Value;
                        }
                    }
                    break;
            }
        }
