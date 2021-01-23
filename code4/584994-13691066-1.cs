            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                SqlXml xmlData =
                reader.GetSqlXml(0);
                XmlReader xmlReader = xmlData.CreateReader();
                xmlReader.MoveToContent();
                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        string elementName = xmlReader.LocalName;
                        xmlReader.Read();
                        Console.WriteLine(elementName + ": " + xmlReader.Value);
                    }
                }
            }
