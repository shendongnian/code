    using (System.IO.FileStream _FileStream = _FileInfo.OpenRead())
                    {
    
                        // Stream to which the file to be upload is written
                        
                        using (System.IO.Stream _Stream = _FtpWebRequest.GetRequestStream())
                        {
                            // Read from the file stream 2kb at a time
                            int contentLen = _FileStream.Read(buff, 0, buffLength);
    
                            // Till Stream content ends
                            while (contentLen != 0)
                            {
                                // Write Content from the file stream to the FTP Upload Stream
                                _Stream.Write(buff, 0, contentLen);
                                contentLen = _FileStream.Read(buff, 0, buffLength);
                            }
    
                            //No need to Close the file stream and the Request Stream
                            
                        }
                    }
