    XmlDocument doc = new XmlDocument();
        doc.Load(Server.MapPath("~/hotspots.xml"));
        XmlNode root = doc.DocumentElement;
        XmlNodeList nodeList = root.SelectNodes("HOTSPOT");
        foreach (XmlNode node in nodeList)
        {
            XmlNode idNode = node.SelectSingleNode("@ID");
            //nodeText = node.SelectSingleNode("ID").ToString();
            if(idNode != null)
            {
                ddlXml.Items.Add("Item - " + idNode.InnerText);
            }
        }
