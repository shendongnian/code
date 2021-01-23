    public Boolean Patch(string path)
        {
            const int BUFFER_SIZE = 512;
            
            // VERY IMPORTANT: The throw operation will cause the stream to remain open the function returns.
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                BinaryReader br = new BinaryReader(fs);
                BinaryWriter bw = new BinaryWriter(fs);
                if (fs.Length != this.rawdata.Length)
                    throw new ArgumentException();
                byte[] cache = new byte[BUFFER_SIZE];
                int readCount = 0, location = 0;
                while ((readCount = br.Read(cache, 0, BUFFER_SIZE)) != 0) 
                {
                    int changeLength = 0;
                    for (int j = 0; j < readCount; j++)
                    {
                        if (cache[j] != rawdata[j + location])
                        {
                            changeLength++;
                        }
                        else if (changeLength > 0)
                        {
                            fs.Position = location + j - changeLength;
                            bw.Write(rawdata, location + j - changeLength, changeLength);
                            fs.Position = location + j;
                            
                            changeLength = 0;
                        }
                    }
                    location += readCount;
                } 
                return true;
            }
        }
