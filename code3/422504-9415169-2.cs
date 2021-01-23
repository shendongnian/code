    public static class ExtensionMethods
    {
        public static void WriteCompressedXml(this DataSet dataset, Stream stream)
        {
            using (GZipStream compressStream = new GZipStream(stream, CompressionMode.Compress))
            {  
                dataSet.WriteXml(compressStream);             
            }
        }
    
        public static void WriteCompressedXml(this DataSet dataset, Stream stream, XmlWriteMode mode)
        {
            using (GZipStream compressStream = new GZipStream(stream, CompressionMode.Compress))
            {  
                dataSet.WriteXml(compressStream, mode);             
            }
        }
    }
