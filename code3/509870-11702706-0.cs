    using System.IO;
    using System.Security.Cryptography;
    using System.Xml.Serialization;
...
    private void WriteToFile(Device device, string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.Create))
        {
            using (CryptoStream cs = new CryptoStream(fs, new ToBase64Transform(), CryptoStreamMode.Write))
            {
                XmlSerializer x = new XmlSerializer(typeof(Device));
                x.Serialize(cs, device);
            }
        }
    }
    private Device ReadFromFile(string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.Open))
        {
            using (CryptoStream cs = new CryptoStream(fs, new FromBase64Transform(), CryptoStreamMode.Read))
            {
                XmlSerializer x = new XmlSerializer(typeof(Device));
                return x.Deserialize(cs) as Device;
            }
        }
    }
