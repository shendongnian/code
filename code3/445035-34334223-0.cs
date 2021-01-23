            using (var outStream = new MemoryStream())
                    {
                        using (var archive = new ZipArchive(outStream, ZipArchiveMode.Create, true))
                        {
                            for (String Url in UrlList)
                            {
                                WebRequest req = WebRequest.Create(Url);
                                req.Method = "GET";
                                var fileInArchive = archive.CreateEntry("FileName"+i+ ".pdf", CompressionLevel.Optimal);
                                using (var entryStream = fileInArchive.Open())
                                using (WebResponse response = req.GetResponse())
                                {
                                    using (var fileToCompressStream = response.GetResponseStream())
                                    {
                                        entryStream.Flush();
                                        fileToCompressStream.CopyTo(entryStream);
                                        fileToCompressStream.Flush();
                                    }
                                }
                               i++;
                            }
    
                        }
                        using (var fileStream = new FileStream(@"D:\test.zip", FileMode.Create))
                        {
                            outStream.Seek(0, SeekOrigin.Begin);
                            outStream.CopyTo(fileStream);
                        }
                    }
