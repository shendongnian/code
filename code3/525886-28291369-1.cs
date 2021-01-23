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
                    int startIndex=0;
                    if (IsContainsHeaderCrLf(buffer2,out startIndex))
                    {
                        endHeader = true;
                       
                        hd.Write(buffer2, 0,startIndex);
                         response.Write(buffer2, startIndex+4,bytes-startIndex-4);
                    }
                    else
                    {
                        hd.Write(buffer2, 0, bytes);
                    }
                }
                else
                {
                    response.Write(buffer2, 0, bytes);
                }
            } while (bytes != 0);
            string headertxt = System.Text.Encoding.UTF8.GetString(hd.ToArray());
            string unziptxt = "";
            string responsetxt = "";
            if (headertxt.Contains("gzip"))
            {
                unziptxt = System.Text.Encoding.UTF8.GetString(Decompress(response.ToArray()));
            }
            else
            {
                responsetxt = System.Text.Encoding.UTF8.GetString(response.ToArray());
            }
            return headertxt + "\r\n\r\n" + unziptxt + responsetxt;
        }
        private bool IsContainsHeaderCrLf(byte[] buffer, out int startIndex)
        {
            for (int i = 0; i <= buffer.Length - 4; i++)
            {
                if (buffer[i] == 13 & buffer[i + 1] == 10 && buffer[i + 2] == 13 && buffer[i + 3] == 10)
                {
                    startIndex = i;
                    return true;
                }
            }
            startIndex = -1;
            return false;
        }
