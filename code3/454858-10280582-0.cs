                    using (Stream stream = new FileStream(
                     pubAttFullPath.ToString(),
                     FileMode.Open,
                     FileAccess.Read,
                     FileShare.Read))
                    {
                        context.Response.AddHeader("Accept-Ranges", "bytes");
                        context.Response.Buffer = false;
    
                        if (context.Request.Headers["Range"] != null)
                        {
                            context.Response.StatusCode = 206;
                            string[] range = context.Request.Headers["Range"].Split(new[] { '=', '-' });
                            startBytes = Convert.ToInt32(range[1]);
                        }
    
                        int dataToRead = size - startBytes;
    
                        context.Response.ContentType = "application/octet-stream";
                        context.Response.AddHeader("Content-Length", dataToRead.ToString());
                        context.Response.AddHeader("Connection", "Keep-Alive");
                        context.Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName, Encoding.UTF8));
    
                        if (startBytes > 0)
                        {
                            context.Response.AddHeader("Content-Range", string.Format(" bytes {0}-{1}/{2}", startBytes, size - 1, size));
                            stream.Seek(startBytes, SeekOrigin.Begin);
                        }
    
                        while (dataToRead > 0)
                        {
                            // Verify that the client is connected.
                            if (context.Response.IsClientConnected)
                            {
                                // Read the data in buffer.
                                int length = stream.Read(buffer, 0, buffer.Length);
    
                                // Write the data to the current output stream.
                                context.Response.OutputStream.Write(buffer, 0, length);
    
                                // Flush the data to the HTML output.
                                context.Response.Flush();
                                dataToRead = dataToRead - length;
                            }
                            else
                            {
                                // prevent infinite loop if user disconnects
                                dataToRead = -1;
                            }
                        }
                    }
