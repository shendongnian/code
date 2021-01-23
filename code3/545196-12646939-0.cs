        private static readonly object _lock = new object();
        public static byte[] readFullStream(Stream st)
        {
            try
            {
                Monitor.Enter(_lock);
                byte[] buffer = new byte[](65536);
                Int32 bytesRead;
                MemoryStream ms = new MemoryStream();
                bool finished = false;
                while (!finished)
                {
                    bytesRead = st.Read(buffer.Value, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        ms.Write(buffer.Value, 0, bytesRead);
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
