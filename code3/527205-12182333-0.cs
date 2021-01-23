            static string ReadMessage(SslStream sslStream)
            {
                // Read the  message sent by the server.
                // The end of the message is signaled using the
                // "<EOF>" marker.
                byte[] buffer = new byte[2048];
                StringBuilder messageData = new StringBuilder();
                int bytes = -1;
                do
                {
                    try
                    {
                        bytes = sslStream.Read(buffer, 0, buffer.Length);
                    }
                    catch (Exception ex)
                    {
                    }
                    // Use Decoder class to convert from bytes to UTF8
                    // in case a character spans two buffers.
                    Decoder decoder = Encoding.ASCII.GetDecoder();
                    char[] chars = new char[decoder.GetCharCount(buffer, 0, bytes)];
                    decoder.GetChars(buffer, 0, bytes, chars, 0);
                    messageData.Append(chars);
                    // Check for EOF.
                    if (messageData.ToString().IndexOf("\r\n") != -1)
                    {
                        break;
                    }
                }
                while (bytes != -1);
                
                return messageData.ToString();
            }
