    private static MemoryStream EncryptStream(XmlDocument xmlDoc, XmlElement elementToEncrypt, string password)
    {
        CspParameters cspParams = new CspParameters();
        cspParams.KeyContainerName = password;
        RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider(cspParams);
        RijndaelManaged sessionKey = null;
        try
        {
            if (xmlDoc == null)
                throw new ArgumentNullException("xmlDoc");
            if (rsaKey == null)
                throw new ArgumentNullException("rsaKey");
            if (elementToEncrypt == null)
                throw new ArgumentNullException("elementToEncrypt");
    
            sessionKey = new RijndaelManaged();
            sessionKey.KeySize = 256;
    
            EncryptedXml eXml = new EncryptedXml();
            byte[] encryptedElement = eXml.EncryptData(elementToEncrypt, sessionKey, false);
    
            EncryptedData edElement = new EncryptedData();
            edElement.Type = EncryptedXml.XmlEncElementUrl;
            edElement.Id = EncryptionElementID;
            edElement.EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncAES256Url);
    
            EncryptedKey ek = new EncryptedKey();
            byte[] encryptedKey = EncryptedXml.EncryptKey(sessionKey.Key, rsaKey, false);
            ek.CipherData = new CipherData(encryptedKey);
            ek.EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncRSA15Url);
            // Save some more information about the key using the EncryptionProperty element.
            // Create a new "EncryptionProperty" XmlElement object. 
            var property = new XmlDocument().CreateElement("EncryptionProperty", EncryptedXml.XmlEncNamespaceUrl);
            // Set the value of the EncryptionProperty" XmlElement object.
            property.InnerText =                        RijndaelManagedEncryption.EncryptRijndael(Convert.ToBase64String(rsaKey.ExportCspBlob(true)),
                            "Your Salt string here");
            // Create the EncryptionProperty object using the XmlElement object. 
            var encProperty = new EncryptionProperty(property);
            // Add the EncryptionProperty object to the EncryptedKey object.
            ek.AddProperty(encProperty);
    
            edElement.KeyInfo = new KeyInfo();
    
            KeyInfoName kin = new KeyInfoName();
            kin.Value = KeyName;
    
            ek.KeyInfo.AddClause(kin);
            edElement.CipherData.CipherValue = encryptedElement;
            edElement.KeyInfo.AddClause(new KeyInfoEncryptedKey(ek));
    
            EncryptedXml.ReplaceElement(elementToEncrypt, edElement, false);
    
            if (sessionKey != null)
            {
                sessionKey.Clear();
            }
            rsaKey.Clear();
            MemoryStream stream = new MemoryStream();
            xmlDoc.Save(stream);
            stream.Position = 0;
            Encoding encodeing = System.Text.UnicodeEncoding.Default;
            return stream;
        }
        catch (Exception)
        {
            if (sessionKey != null)
            {
                sessionKey.Clear();
            }
            rsaKey.Clear();
            throw;
        }
    }
    private static MemoryStream DecryptStream(XmlDocument xmlDoc, string password)
    {
        CspParameters cspParams = new CspParameters();
        cspParams.KeyContainerName = password;
        RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider(cspParams);
        var keyInfo = xmlDoc.GetElementsByTagName("EncryptionProperty")[0].InnerText;
            rsaKey.ImportCspBlob(
                Convert.FromBase64String(RijndaelManagedEncryption.DecryptRijndael(keyInfo,
                    "Your Salt string here")));
        EncryptedXml exml = null;
        try
        {
            if (xmlDoc == null)
                throw new ArgumentNullException("xmlDoc");
            if (rsaKey == null)
                throw new ArgumentNullException("rsaKey");
    
            exml = new EncryptedXml(xmlDoc);
            exml.AddKeyNameMapping(KeyName, rsaKey);
    
            exml.DecryptDocument();
            rsaKey.Clear();
    
            MemoryStream outStream = new MemoryStream();
            xmlDoc.Save(outStream);
            outStream.Position = 0;
            return outStream;
        }
        catch (Exception)
        {
            rsaKey.Clear();
            throw;
        }
    }
