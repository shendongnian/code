    void LikeThat(byte[] file)
        {
            var ms = new System.IO.MemoryStream(file);
            while (ms.Length > 0)
            {
                var b=  new byte[4096];
                ms.Read(b, 0, 4096);
                //now b contains your chunk, just transmit it!
            }
        }
