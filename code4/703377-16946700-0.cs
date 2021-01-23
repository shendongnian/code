            XmlDocument doc = new XmlDocument();
            try { doc.Load("c:\\temp\\test.xml"); }
            catch (Exception ex) { }
            XmlElement root = doc.DocumentElement;
            String strOriginalString = "";
            foreach (XmlNode node in root.SelectNodes("/Comprobante/Addenda"))
            {
                XmlNode child = node.SelectSingleNode("EstadoDeCuentaCombustible/cadenaOriginal");
                if (child != null)
                {
                    strOriginalString = child.InnerText;
                    break;
                }
            }
