    XmlTextWriter writer = new XmlTextWriter("D:\\nefe.xml", System.Text.Encoding.UTF8);
    writer.WriteStartDocument();
    writer.WriteStartElement("Email");
    writer.WriteAttributeString("version","2.00");
    writer.WriteAttributeString("xmlns","Http://www.portalfiscal.inf.br/nfe");
    writer.WriteEndElement();
    writer.WriteEndDocument();
    writer.Close();
