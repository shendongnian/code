    public void XmlWriter(List<Email> Femails)
    {
        #region On Error Retry and retrycount with xml file
     
        string ErrorXmlFile = @"../../Retries.xml";
        try
        {
            if (!File.Exists(ErrorXmlFile))
            {
                XmlSerializer xSeriz = new XmlSerializer(typeof(List<Email>));
                FileStream fs = File.Open(ErrorXmlFile, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                xSeriz.Serialize(fs, Femails);
                foreach (Email email in Femails)
                {
                    SaveAttachment(email);
                }
               
            }
            else 
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(ErrorXmlFile);
                foreach (Email email in Femails)
                {
                    XmlNode xnode = doc.CreateNode(XmlNodeType.Element, "BLACKswastik", null);
                    XmlSerializer xSeriz = new XmlSerializer(typeof(Email));
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    XmlWriterSettings writtersetting = new XmlWriterSettings();
                    writtersetting.OmitXmlDeclaration = true;
                    StringWriter stringwriter = new StringWriter();
                    using (XmlWriter xmlwriter = System.Xml.XmlWriter.Create(stringwriter, writtersetting))
                    {
                        xSeriz.Serialize(xmlwriter, email, ns);
                    }
                    xnode.InnerXml = stringwriter.ToString();
                    XmlNode bindxnode = xnode.SelectSingleNode("Email");
                    doc.DocumentElement.AppendChild(bindxnode);
                    SaveAttachment(email);
                }
                doc.Save(ErrorXmlFile);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        #endregion
    }
