    public HttpResponseMessage GetItemsInZip(int id)
        {           
                var itemsToWrite = // return array of objects based on id;
                // create zip file stream
                MemoryStream archiveStream = new MemoryStream();
                using (ZipArchive archiveFile = new ZipArchive(archiveStream, ZipArchiveMode.Create, true))
                {
                    foreach (var item in itemsToWrite)
                    {
                        // create file streams
                        // add the stream to zip file
                        
                        var entry = archiveFile.CreateEntry(item.FileName);
                        using (StreamWriter sw = new StreamWriter(entry.Open()))
                        {
                            sw.Write(item.Content);
                        }
                    }
                }
                // return the zip file stream to http response content                
                HttpResponseMessage responseMsg = new HttpResponseMessage(HttpStatusCode.OK);                
                responseMsg.Content = new ByteArrayContent(archiveStream.ToArray());
                archiveStream.Dispose();
                responseMsg.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = "test.zip" };
                responseMsg.Content.Headers.ContentType = new MediaTypeHeaderValue("application/zip");
                                
                return responseMsg;          
        }
