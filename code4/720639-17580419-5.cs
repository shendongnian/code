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
    string sessKeyName = "helloworldkey";
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
    encryptedElement.KeyInfo.AddClause(new KeyInfoName(sessKeyName));
    // encrypt the session key and add keyinfo's
    int keyID = 0;
    foreach (var pk in publicKeys)
    {
        var encKey = new EncryptedKey()
        {
            CipherData = new CipherData(EncryptedXml.EncryptKey(sessKey.Key, pk, false)),
            EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncRSA15Url),
            Recipient = string.Format("recipient{0}@foobar.com", ++keyID),
            CarriedKeyName = sessKeyName,
        };
        encKey.KeyInfo.AddClause(new KeyInfoName(encKey.Recipient));
        encryptedElement.KeyInfo.AddClause(new KeyInfoEncryptedKey(encKey));
    }
    // update the xml
    EncryptedXml.ReplaceElement(elementToEncrypt, encryptedElement, false);
    // show the result
    Console.Write(xdoc.InnerXml);
    Console.ReadLine();
    Console.WriteLine(new string('-', 80));
