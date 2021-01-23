    public static class CompressedBinaryConverter 
	{
        public static byte[] ToByteArray(object o)
        {
            if (o == null)
                return new byte[0];
            byte[] buffer;
            using (MemoryStream instream = new MemoryStream(),
                 outStream = new MemoryStream())
            {
                using (GZipStream zipStream = new GZipStream(outStream, CompressionMode.Compress))
                {
                    new BinaryFormatter().Serialize(instream, o);
                    instream.CopyTo(zipStream);
                    zipStream.Close();
                    buffer = outStream.ToArray();
                }
            }
            return buffer;
        }
        public static object ToObject(byte[] byteArray)
        {
            if (byteArray.Length == 0)
                return null;
            object obj = null;
            using (MemoryStream decomStream = new MemoryStream(byteArray),
                ms = new MemoryStream())
            {
                using (GZipStream hgs = new GZipStream(decomStream, CompressionMode.Decompress))
                {
                    hgs.CopyTo(ms);
                    hgs.Close();
                    obj = new BinaryFormatter().Deserialize(ms);
                }
            }
            return obj;
        }
	}
