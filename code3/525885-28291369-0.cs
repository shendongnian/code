    // Read response
                byte[] buffer2 = new byte[4096];
                MemoryStream hd = new MemoryStream();
                MemoryStream response = new MemoryStream();
                bool endHeader = false;
                do
                {
    
    
    // your networkstream object instead > "stream"
    
                    bytes = stream.Read(buffer2, 0, buffer2.Length);
                  
                    if (!endHeader)
                    {
                        int indexZero = buffer2.ToArray().ToList().FindIndex(o => o == 0);
                        if (indexZero > -1)
                        {
                            endHeader = true; 
                            hd.Write(buffer2, 0, indexZero - 1);
                        }
                        else
                        {
                            hd.Write(buffer2, 0, buffer2.Length);
                        }
    
                    }
                    else
                    {
                        response.Write(buffer2, 0, buffer2.Length);
                        
                    }
                } while (bytes != 0);
    
                string headertxt= System.Text.Encoding.UTF8.GetString(hd.ToArray());
                string unziptxt = "";
                string responsetxt = "";
                if (headertxt.Contains("gzip"))
                {
                    unziptxt = System.Text.Encoding.UTF8.GetString(Decompress(response.ToArray()));
                }
                else
                {
                     responsetxt= System.Text.Encoding.UTF8.GetString(response.ToArray());
                }
                return headertxt + "\r\n\r\n" + unziptxt + responsetxt;
