        List<byte> lastBuf = new List<byte>();
        List<byte[]> Extract(byte[] data, byte delim)
        {
            List<byte[]> result = new List<byte[]>();
            for (int i = 0; i < data.Length; i++)
            {
                if (lastBuf.Count > 0)
                {
                    if(data[i] == delim)
                    {
                        result.Add(lastBuf.ToArray());
                        lastBuf.Clear();
                    }
                    else
                    {
                        lastBuf.Add(data[i]);
                    }
                }
                else 
                { 
                    if(data[i] != 126)
                    {
                        lastBuf.Add(data[i]);
                    }
                }
            }
            return result;
        }
