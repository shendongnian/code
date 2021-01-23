                    FileInfo fInfo = new FileInfo(fileName);//fileName is the full path of the file.
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(blobSaSUrl);
                    NameValueCollection requestHeaders = new NameValueCollection();
                    requestHeaders.Add("x-ms-blob-type", "BlockBlob");
                    req.Method = "PUT";
                    req.Headers.Add(requestHeaders);
                    req.ContentLength = fInfo.Length;
                    byte[] fileContents = new byte[fInfo.Length];
                    using (FileStream fs = fInfo.OpenRead())
                    {
                        fs.Read(fileContents, 0, fileContents.Length);
                        using (Stream s = req.GetRequestStream())
                        {
                            s.Write(fileContents, 0, fileContents.Length);
                        }
                        using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
                        {
                        }
                    }
