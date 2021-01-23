    // example xml
    XmlDocument xdoc = new XmlDocument();
    xdoc.PreserveWhitespace = true;
    xdoc.LoadXml(@"<root><encryptme>hello world</encryptme></root>");
    var elementToEncrypt = (XmlElement)xdoc.GetElementsByTagName("encryptme")[0];
    // keys
    // rsa keys would normally be pulled from a store
    RSA rsaKey1 = new RSACryptoServiceProvider();
    RSA rsaKey2 = new RSACryptoServiceProvider();
    var publicKeys = new[] { rsaKey1, rsaKey2 };
    var sessKey = new RijndaelManaged() { KeySize = 256 };
    // encrypt
    var encXml = new EncryptedXml();
    var encryptedElement = new EncryptedData()
    {
        Type = EncryptedXml.XmlEncElementUrl,
        EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncAES256Url),
        KeyInfo = new KeyInfo()
    };
    encryptedElement.CipherData.CipherValue = encXml.EncryptData(elementToEncrypt, sessKey, false);
    // encrypt the session key and add keyinfo's
    int keyID = 0;
    foreach (var pk in publicKeys)
    {
        var encKey = new EncryptedKey()
        {
            CipherData = new CipherData(EncryptedXml.EncryptKey(sessKey.Key, rsaKey1, false)),
            // this has to match the public key algorithm, this example uses all RSA
            EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncRSA15Url),
            // typically, this would be the thumbprint or some other identifying 
            // string that can be used to get the private key
            Recipient = string.Format("recipient{0}@foobar.com", ++keyID)
        };
        encKey.KeyInfo.AddClause(new KeyInfoName(encKey.Recipient));
        encryptedElement.KeyInfo.AddClause(new KeyInfoEncryptedKey(encKey));
    }
    // update the xml
    EncryptedXml.ReplaceElement(elementToEncrypt, encryptedElement, false);
    // show the result
    Console.Write(xdoc.InnerXml);
    Console.ReadLine();
