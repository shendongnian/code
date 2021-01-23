    void LikeThat(byte[] file)
        {
            var ms = new System.IO.MemoryStream(file);
            var b=  new byte[4096];
            while (ms.Length > 0)
            {
                ms.Read(b, 0, 4096);
                //now b contains your chunk, just transmit it!
            }
        }
