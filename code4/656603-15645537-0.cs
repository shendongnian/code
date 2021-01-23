    using (var hash = new SHA512Cng())
    using (var stream = new CryptoStream(Stream.Null, hash, CryptoStreamMode.Write))
    using (var writer = XmlWriter.Create(stream))
    using (var reader = XmlReader.Create("input.xml"))
    {
        while (reader.Read())
        {
            // ... write node to writer ...
        }
        writer.Flush();
        stream.FlushFinalBlock();
        var result = hash.Hash;
    }
