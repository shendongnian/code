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
                    int changeStart = -1;
                    int changeLength = 0;
                    for (int j = 0; j < readCount; j++)
                    {
                        if (cache[j] != rawdata[j + location])
                        {
                            if (changeStart < 0)
                                changeStart = j;
                            changeLength++;
                        }
                        else if (changeLength > 0)
                        {
                            if (changeLength > 0)
                            {
                                fs.Position = location + changeStart;
                                bw.Write(rawdata, location + changeStart, changeLength);
                                fs.Position = location + j;
                            }
                            changeStart = -1;
                            changeLength = 0;
                        }
                    }
                    location += readCount;
                } 
                return true;
            }
        }
