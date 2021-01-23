    // Get the object used to communicate with the server.
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create("*******/site/wwwroot/wwwroot/images/" + TempFileName);
                    request.Method = WebRequestMethods.Ftp.UploadFile;
                    request.UseBinary = true;
                    request.KeepAlive = false;
                    request.Method = "STOR";
                    request.Credentials = new NetworkCredential("***", "****");
    
                    // Copy the contents of the file to the request stream.
                    byte[] fileContents = null;
    
                    if (vehicle.FileUpload.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            await vehicle.FileUpload.CopyToAsync(ms);
                            var fileBytes = ms.ToArray();
                            fileContents = fileBytes;
                        }
                    }
                    request.ContentLength = fileContents.Length;
    
                    using (Stream requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(fileContents, 0, fileContents.Length);
                    }
