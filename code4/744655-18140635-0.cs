     public byte[] ToByteArray(object o)
        {
            if (o == null)
                return new byte[0];
            using (MemoryStream outStream = new MemoryStream())
            {
                using (GZipStream zipStream = new GZipStream(outStream, CompressionMode.Compress))
                {
                    using (MemoryStream stream = new MemoryStream())
                    {
                        new BinaryFormatter().Serialize(stream, o);
                        stream.Position = 0;
                        stream.CopyTo(zipStream);
                        zipStream.Close();
                        return outStream.ToArray();
                    }
                }
            }
        }
      public object ToObject(byte[] byteArray)
        {
            if (byteArray.Length == 0)
                return null;
            using (MemoryStream decomStream = new MemoryStream(byteArray), ms = new MemoryStream())
            {
                using (GZipStream hgs = new GZipStream(decomStream, CompressionMode.Decompress))
                {
                    hgs.CopyTo(ms);
                    decomStream.Close();
                    hgs.Close();
                    ms.Position = 0;
                    return new BinaryFormatter().Deserialize(ms);
                }
            }
        }
