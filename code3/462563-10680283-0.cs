        /// <summary>
        /// The download file.
        /// </summary>
        /// <param name="state">
        /// The state.
        /// </param>
        /// <exception cref="InvalidDataException">
        /// </exception>
        private void DownloadFile()
        {
            string url = "http://localhost:16935/Transfer.ashx";
            bool cancel = false;
            string savePath = "C:/Temp";
            try
            {
                // Put the object argument into an int variable
                int start = 0;
                if (File.Exists(savePath))
                {
                    start = (int)new System.IO.FileInfo(savePath).Length;
                }
                // Create a request to the file we are downloading
                var request = (HttpWebRequest)WebRequest.Create(url);
                // Set the starting point of the request
                request.AddRange(start);
                // Set default authentication for retrieving the file
                request.Credentials = CredentialCache.DefaultCredentials;
                
                // Retrieve the response from the server
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    // check file lenght
                    int fileLength = 0;
                    int.TryParse(resp.Headers.Get("Content-Length"), out fileLength);
                    
                    // Open the URL for download 
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        // Create a new file stream where we will be saving the data (local drive)
                        using (var fs = new FileStream(savePath, FileMode.Append, FileAccess.Write, FileShare.Read))
                        {
                            // It will store the current number of bytes we retrieved from the server
                            int bytesSize;
                            // A buffer for storing and writing the data retrieved from the server
                            var downBuffer = new byte[2048];
                            // Loop through the buffer until the buffer is empty
                            while ((bytesSize = responseStream.Read(downBuffer, 0, downBuffer.Length)) > 0)
                            {
                                var args = new CancelEventArgs(false);
                                this.OnCancel(args);
                                if (args.Cancel)
                                {
                                    cancel = true;
                                    break;
                                }
                                // Write the data from the buffer to the local hard drive
                                fs.Write(downBuffer, 0, bytesSize);
                                fs.Flush();
                                float percentComplete = 0;
                                if (fileLength > 0)
                                {
                                    percentComplete = (100 * fs.Length) / (float)fileLength;
                                    if (percentComplete > 100)
                                    {
                                        percentComplete = 100;
                                    }
                                }
                                this.OnProgressChanged(new ProgressChangedEventArgs((int)percentComplete));
                            }
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
               throw;
            }            
        }
