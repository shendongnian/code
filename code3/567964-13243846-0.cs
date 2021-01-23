    string prevColumnName = "";
    while (reader.Read())
    {
        if (reader.NodeType == XmlNodeType.Element)
        {
            element = reader.Name;
        }
        else if (reader.NodeType == XmlNodeType.Text)
        {
            switch (element.ToLower())
            {
                case "column":
                    prevColumnName = reader.Value;
                    break;
                case "int":
                    if (prevColumnName.Equals("Size"))
                    {
                        int size;
                        if (int.TryParse(reader.Value, out size))
                        {
                            // here you can get the 'Size'
                        }
                    }
                    break;
                case "string":
                    break;
            }
        }
    }
