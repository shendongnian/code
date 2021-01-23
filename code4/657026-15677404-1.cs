    for (int i = 0; i < reverseImageFiles.Length; i++)
            {
                string curBMP = reverseImageFiles[i];
                using(Stream inStream = File.OpenRead(curBMP))
                using (Stream writeStream = new FileStream(outputBMP,FileMode.Append,FileAccess.Write,FileShare.None))
                {
                    BinaryReader reader = new BinaryReader(inStream);
                    BinaryWriter writer = new BinaryWriter(writeStream);
                    byte[] buffer = new Byte[134217728];
                    int bytesRead;
                    int totalBytes = 0;
                    while ((bytesRead = inStream.Read(buffer, 0, 134217728)) > 0)
                    {
                        totalBytes += bytesRead;
                        if (totalBytes <= 134217729)  //if it's the first round of reading to the buffer, you need to get rid of 54-byte BMP header
                        {
                            writeStream.Write(buffer, 54, bytesRead - 54);
                        }
                        else
                        {
                            writeStream.Write(buffer, 0, bytesRead);
                        }
                    }
                }
            }
