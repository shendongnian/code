        ...
                byte[] buffer = new byte[65536]; // 64KB chunks 
                int read; 
                long totalRead; 
                int bufferPosition = 0;
                bool changedLength = false;
               
                while ((read = stream.Read(buffer, bufferPosition, buffer.Length)) > 0) 
                { 
                    totalRead += read;
                    if (!changedLength)
                    {
                       if (totalRead < 8) 
                       {
                           // need more bytes
                           bufferPosition += read;
                           continue;
                       } 
                       else
                       {
                           const uint fileLength = uint.MaxValue - 8;
                           buffer[4] = (byte)(fileLength         && 0xFF);
                           buffer[5] = (byte)((fileLength >>  8) && 0xFF);
                           buffer[6] = (byte)((fileLength >> 16) && 0xFF);
                           buffer[7] = (byte)((fileLength >> 24) && 0xFF);
                           changedLength = true;
                           bufferPosition = 0;
                           var pos = ms.Position; 
                           ms.Position = ms.Length; 
                           ms.Write(buffer, 0, (int)totalRead); 
                           ms.Position = pos; 
                       }
                    }                    
                    else
                    {
                        var pos = ms.Position; 
                        ms.Position = ms.Length; 
                        ms.Write(buffer, 0, read); 
                        ms.Position = pos; 
                    }
                } 
          
        ...
