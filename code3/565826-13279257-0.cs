    SPSecurity.RunWithElevatedPrivileges(delegate()
    {
        SPFile formFile = workflowProperties.Item.File;
        MemoryStream ms = new MemoryStream(formFile.OpenBinary());
        XmlTextReader rdr = new XmlTextReader(ms);
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(rdr);
        rdr.Close();
        ms.Close();
        XmlNamespaceManager nsm = new XmlNamespaceManager(xmlDoc.NameTable);
        nsm.AddNamespace("my", "http://schemas.microsoft.com/office/infopath/2003/myXSD/2012-09-04T20:19:31");
        XmlNode nodeSignatureCollection = xmlDoc.DocumentElement.SelectSingleNode("my:signatures1", nsm);
        if (nodeSignatureCollection != null)
        {
            if (nodeSignatureCollection.HasChildNodes)
            {
                foreach (XmlNode nodeSignature in nodeSignatureCollection.ChildNodes)
                {
                    //  HERE IT IS!!!
                    if (nodeSignature.HasChildNodes && !nodeSignature.IsReadOnly) nodeSignature.RemoveAll();
                }
            }
        }
        byte[] xmlData = System.Text.Encoding.UTF8.GetBytes(xmlDoc.OuterXml);
        formFile.SaveBinary(xmlData);
        formFile.Update();
    });
