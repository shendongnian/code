            var xmlReader = new XmlTextReader("c:\\temporary\\cars.xml");
            while (xmlReader.Read())
            {
                switch(xmlReader.NodeType)
                {
                    case XmlNodeType.XmlDeclaration:
                    case XmlNodeType.Element:
                    case XmlNodeType.Comment:
                        sb.AppendFormat("{0}: {1}={2}", xmlReader.NodeType, xmlReader.Name, xmlReader.Value);
                        sb.AppendLine();
                        break;
                    case XmlNodeType.Text:
                        sb.AppendFormat("   - Value: {0}", xmlReader.Value);
                        sb.AppendLine();
                        break;
                }
                if(xmlReader.HasAttributes)
                {
                    while(xmlReader.MoveToNextAttribute())
                    {
                        sb.AppendFormat("   - Attribute: {0}={1}", xmlReader.Name, xmlReader.Value);
                        sb.AppendLine();
                    }
                }
            }
