    public XmlWriter GetEncryptedXmlWriter(string dest)
    {
        try
        {
            // Create a decrytor to perform the stream transform.
            ICryptoTransform encryptor = _Provider.CreateEncryptor();
    
            FileStream fs = new FileStream(dest, System.IO.FileMode.Create);
            CryptoStream cs = new CryptoStream(fs, _Provider.CreateEncryptor(), CryptoStreamMode.Write);
    
            XmlWriterSettings settings = new XmlWriterSettings { Indent = true };
            return XmlTextWriter.Create(cs, settings);
    
        }
        catch (Exception ex)
        { throw ex; }
    }
