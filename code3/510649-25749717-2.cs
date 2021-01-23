    using (var fs = new FileStream(path, System.IO.FileMode.Create))
    {
        using (var cs = new CryptoStream(fs, _Provider.CreateEncryptor(), CryptoStreamMode.Write))
        {
            using (var writer = XmlTextWriter.Create(cs))
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 3;
                MyFileObj.ourSerializer.Serialize(writer, xmlFile, ourXmlNamespaces);
            }
        }
    }
    
