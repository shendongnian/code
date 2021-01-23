    StreamReader stream = new StreamReader(filePath);
    XmlReader reader = XmlReader.Create(stream, settings);
            while (reader.Read())
            {
                reader.MoveToContent();
                // Parse the file and display each of the nodes.
                while (reader.Read())
                {
                    reader.MoveToElement();
                    if (reader.Name.Equals("Category") && reader.NodeType != XmlNodeType.EndElement)
                    {
                        Response.Write("<b>" + reader.Name + "</b>" + "<br/>");
                    }
                    else if (reader.Name.Equals("Name") && reader.NodeType != XmlNodeType.EndElement)
                    {
                        Response.Write("<span style='color:#1884A5'>" + reader.Name + "</span>" + " : ");
                        Response.Write(reader.ReadElementString() + "<br/>");
                    }
             }
