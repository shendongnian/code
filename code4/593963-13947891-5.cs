    public byte[] Encrypt(object obj)
    {
        var settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true,
                Encoding = new UTF8Encoding(false)
            };
        var ns = new XmlSerializerNamespaces();
        ns.Add("", "");
        var xmlSerializer = new XmlSerializer(obj.GetType());
        using (var encryptor = rijndael.CreateEncryptor())
        using (var stream = new MemoryStream())
        using (var crypto = new CryptoStream(stream, encryptor, CryptoStreamMode.Write))
        {
            using (var xmlWriter = XmlWriter.Create(crypto, settings))
            {
                xmlSerializer.Serialize(xmlWriter, obj, ns);
                xmlWriter.Flush();
            }
            crypto.FlushFinalBlock();
            return stream.ToArray();
        }
    }
