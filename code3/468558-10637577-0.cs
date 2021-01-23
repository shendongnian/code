           using (StreamReader reader = File.OpenText(fileName))
           {
                char[] buffer = new char[8192];
                bool eof = false;
                
                while (!eof)
                {
                    int numBytes = (reader.ReadBlock(buffer, 0, buffer.Length));
                    if (numBytes>0)
                    {
                        using (StreamWriter writer = File.CreateText(outputFile))
                        {
                            writer.Write(buffer, 0, numBytes);
                        }
                    } else {
                        eof = true;
                    }
                    
                }
            }
