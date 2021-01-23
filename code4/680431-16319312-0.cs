      public void Write(Byte[] bytes,System.IO.Stream stream)
        {
            int chunkSize = 2 * 1024; //2k
            int offset = 0;
            do
            {
                var count = offset + chunkSize > bytes.Length ? bytes.Length - offset : chunkSize;
                stream.Write(bytes, offset, count);
                offset += count;
                
            } while (offset < bytes.Length);
        }
