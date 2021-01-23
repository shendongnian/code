                    long bytesToRead = (CDataEnd - CDataStart);
                    using (CryptoStream cryptoStremFromBase64 = new CryptoStream(context.OutStream, new FromBase64Transform(FromBase64TransformMode.IgnoreWhiteSpaces), CryptoStreamMode.Write))
                    {
                        byte[] bytebuffer = new byte[bytesToRead % 10485760];
                        readbytes = context.InStream.Read(bytebuffer, 0, bytebuffer.Length);
                        cryptoStremFromBase64.Write(bytebuffer, 0, bytebuffer.Length);
                        while (context.InStream.Position < CDataEnd)
                        {
                            WriteToLog("Context.Instream.Position = " + context.InStream.Position.ToString(), context, startingTime);
                            byte[] bytebuffer2 = new byte[10485760];
                            readbytes = context.InStream.Read(bytebuffer2, 0, bytebuffer2.Length);
                            cryptoStremFromBase64.Write(bytebuffer2, 0, bytebuffer2.Length);
                        }
                        
                        cryptoStremFromBase64.Flush();
                    }
