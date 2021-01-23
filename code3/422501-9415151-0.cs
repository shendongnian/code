    public void Compress(DataSet ds)
    {
        using (FileStream fs = new FileStream(uri, FileMode.Open))
        {
            using (FileStream outFile = File.Create(compressedfileuri))
            {
                using (GZipStream compress = new GZipStream(outFile, CompressionMode.Compress))
                {
                    ds.WriteXml(compress);
                }
            }
        }
    }
