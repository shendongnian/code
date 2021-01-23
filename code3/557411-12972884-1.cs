         using (Stream requestStream = webRequest.GetRequestStream())
         {
                  // write boundary bytes
                  string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
                  byte[] boundaryBytes = System.Text.Encoding.ASCII.GetBytes("--" + boundary + "\r\n");
                  requestStream.Write(someBoundaryBytes, 0, someBoundaryBytes.Length);
                  // write header bytes.
                  requestStream.Write(someHeaderBytes, 0, someHeaderBytes.Length);
                  using (MemoryStream memoryStream = new MemoryStream(imageBytes))
                  {
                          byte[] buffer = new byte[4096];
                          int bytesRead = 0;
                          while ((bytesRead = memoryStream.Read(buffer, 0, buffer.Length)) != 0)
                          {
                                  requestStream.Write(buffer, 0, bytesRead);
                          }
                   }
                   // write trailing boundary bytes.
                   byte[] trailerBytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
                   requestStream.Write(trailerBytes, 0, trailerBytes.Length);
           }
           using (HttpWebResponse wr = (HttpWebResponse)webRequest.GetResponse())
           {
                   using (Stream response = wr.GetResponseStream())
                   {
                        // handle response stream.
                   }
           }
         
