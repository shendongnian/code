        // Binary File Copy
        public static void mergeFiles(string strFileIn1, string strFileIn2, string strFileOut, out string strError)
        {
            strError = String.Empty;
            try
            {
                using (FileStream streamIn1 = File.OpenRead(strFileIn1))
                using (FileStream streamIn2 = File.OpenRead(strFileIn2))
                using (FileStream writeStream = File.OpenWrite(strFileOut))
                {
                    BinaryReader reader = new BinaryReader(streamIn1);
                    BinaryWriter writer = new BinaryWriter(writeStream);
                    // create a buffer to hold the bytes. Might be bigger.
                    byte[] buffer = new Byte[1024];
                    int bytesRead;
                    // while the read method returns bytes keep writing them to the output stream
                    while ((bytesRead =
                            streamIn1.Read(buffer, 0, 1024)) > 0)
                    {
                        writeStream.Write(buffer, 0, bytesRead);
                    }
                    while ((bytesRead =
                            streamIn2.Read(buffer, 0, 1024)) > 0)
                    {
                        writeStream.Write(buffer, 0, bytesRead);
                    }
                }
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
        }
