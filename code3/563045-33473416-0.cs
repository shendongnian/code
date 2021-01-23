            MemoryStream memoryFilePDf = new MemoryStream();
            MemoryStream memoryFileXml = new MemoryStream();
            FilePdf = null;
            FileXml = null;
            using (var zipStream = await file.OpenStreamForReadAsync())
            {
                using (MemoryStream zipMemoryStream = new MemoryStream((int)zipStream.Length))
                {
                    await zipStream.CopyToAsync(zipMemoryStream);
                    try
                    {
                        using (var archive = ZipArchive.Open(zipMemoryStream, PassWord))
                        {
                            bool isFilePdf = false;
                            foreach (var entry in archive.Entries)
                            {
                                if (!entry.Key.ToLower().EndsWith(".pdf") && !entry.Key.ToLower().EndsWith(".xml"))
                                {
                                    continue;
                                }
                                if (entry.Key.ToLower().EndsWith(".pdf"))
                                {
                                    isFilePdf = true;
                                    entry.WriteTo(memoryFilePDf);
                                }
                                else
                                {
                                    isFilePdf = false;
                                    entry.WriteTo(memoryFileXml);
                                }
                                var fileName = entry.Key.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault();
                                var createFile = await ApplicationData.Current.TemporaryFolder.CreateFileAsync(fileName, Windows.Storage.CreationCollisionOption.GenerateUniqueName);
                                using (IRandomAccessStream stream = await createFile.OpenAsync(FileAccessMode.ReadWrite))
                                {
                                    // Write compressed data from memory to file
                                    using (Stream outstream = stream.AsStreamForWrite())
                                    {
                                        byte[] buffer = isFilePdf ? memoryFilePDf.ToArray() : memoryFileXml.ToArray();
                                        outstream.Write(buffer, 0, buffer.Length);
                                        outstream.Flush();
                                    }
                                }
                                if (isFilePdf)
                                {
                                    FilePdf = createFile;
                                }
                                else
                                {
                                    FileXml = createFile;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
		}
