        new Thread(delegate(object o) 
        { 
            var req = WebRequest.Create(url); 
            req.Credentials = GetCredential(url); 
            req.PreAuthenticate = true; 
 
            var changedLength = false;
            var response = req.GetResponse(); 
 
            using (var stream = response.GetResponseStream()) 
            { 
                byte[] buffer = new byte[65536]; // 64KB chunks 
                int read; 
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0) 
                { 
                    if (!changedLength)
                    {
                        if (read >= 8)
                        {
                            const uint length = uint.MaxValue - 8;
                            buffer[4] = (byte)(length         & 0xFF);
                            buffer[5] = (byte)((length >>  8) & 0xFF);
                            buffer[6] = (byte)((length >> 16) & 0xFF);
                            buffer[7] = (byte)((length >> 24) & 0xFF);
                            changedLength = true;
                        }
                        // else store bytes read in a secondary buffer until we 
                        // have at least 8 bytes, and then do the conversion
                    }
                    var pos = ms.Position; 
                    ms.Position = ms.Length; 
                    ms.Write(buffer, 0, read); 
                    ms.Position = pos; 
                } 
            } 
        }).Start(); 
