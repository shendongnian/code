    using System.Data;
    using System.IO;
    using System.IO.Compression;
    using System.IO.MemoryMappedFiles;
    // ...
    public void WriteToMemoryMap(DataSet ds, string key, string fileName)
    {
        var bytes = CompressData(ds);
        using (MemoryMappedFile objMf = MemoryMappedFile.CreateFromFile(fileName, FileMode.OpenOrCreate, key, bytes.Length))
        {
            using (MemoryMappedViewAccessor accessor = objMf.CreateViewAccessor())
            {
                accessor.WriteArray(0, bytes, 0, bytes.Length);
            }
        }
    }
    public DataSet ReadFromMemoryMap(string fileName)
    {
        var fi = new FileInfo(fileName);
        var length = (int)fi.Length;
        var newBytes = new byte[length];
        using (MemoryMappedFile objMf = MemoryMappedFile.CreateFromFile(fileName, FileMode.Open))
        {
            using (MemoryMappedViewAccessor accessor = objMf.CreateViewAccessor())
            {
                accessor.ReadArray(0, newBytes, 0, length);
            }
        }
        return DecompressData(newBytes);
    }
    public byte[] CompressData(DataSet ds)
    {
        try
        {
            byte[] data = null;
            var memStream = new MemoryStream();
            var zipStream = new GZipStream(memStream, CompressionMode.Compress);
            ds.WriteXml(zipStream, XmlWriteMode.WriteSchema);
            zipStream.Close();
            data = memStream.ToArray();
            memStream.Close();
            return data;
        }
        catch (Exception)
        {
            return null;
        }
    }
    public DataSet DecompressData(byte[] data)
    {
        try
        {
            var memStream = new MemoryStream(data);
            var unzipStream = new GZipStream(memStream, CompressionMode.Decompress);
            var objDataSet = new DataSet();
            objDataSet.ReadXml(unzipStream, XmlReadMode.ReadSchema);
            unzipStream.Close();
            memStream.Close();
            return objDataSet;
        }
        catch (Exception)
        {
            return null;
        }
    }
