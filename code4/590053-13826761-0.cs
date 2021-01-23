            public static byte[] readFullStream(Stream st, Int32 BufferSize)
            {
                try
                {
                    Monitor.Enter(_lock);
                    byte[] buffer = new byte[BufferSize];
                    Int32 bytesRead;
                    MemoryStream ms = new MemoryStream();
                    bool finished = false;
                    while (!finished)
                    {
                        bytesRead = st.Read(buffer, 0, buffer.Length);
                        if (bytesRead > 0)
                        {
                            ms.Write(buffer, 0, bytesRead);
                        }
                        else
                        {
                            finished = true;
                        }
                    }
                    return ms.ToArray();
                }
                finally
                {
                    Monitor.Exit(_lock);
                }
            }
