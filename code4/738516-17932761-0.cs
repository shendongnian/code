            string filePath = "...";
            //Create file.
            using (FileStream fileStream = File.Create(filePath))
            {
                //Create archive infrastructure.
                using (ZipArchive archive = new ZipArchive(fileStream, ZipArchiveMode.Create, true, Encoding.UTF8))
                {
                    SqlDataReader sqlReader = null;
                    //Reading each row into a separate text file in the archive.
                    while(sqlReader.Read())
                    {
                        string record = sqlReader.GetString(0);
                        //Archive entry is a file inside archive.
                        ZipArchiveEntry entry = archive.CreateEntry("...", CompressionLevel.Optimal);
                        //Get stream to write the archive item body.
                        using (Stream entryStream = entry.Open())
                        {
                            //All you need here is to write data into archive item stream.
                            byte[] recordData = Encoding.Unicode.GetBytes(record);
                            MemoryStream recordStream = new MemoryStream(recordData);
                            recordStream.CopyTo(entryStream);
                            //Flush the archive item to avoid data loss on dispose.
                            entryStream.Flush();
                        }
                    }
                }
            }
