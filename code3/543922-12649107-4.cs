        ConcurrentQueue<byte[]> writePendingData = new ConcurrentQueue<byte[]>();
        bool sendingData = false;
        void EnqueueDataForWrite(SslStream sslStream, byte[] buffer)
        {
            if (buffer == null)
                return;
            writePendingData.Enqueue(buffer);
            lock (writePendingData)
            {
                if (sendingData)
                {
                    return;
                }
                else
                {
                    sendingData = true;
                }
            }
            Write(sslStream);            
        }
        void Write(SslStream sslStream)
        {
            byte[] buffer = null;
            try
            {
                if (writePendingData.Count > 0 && writePendingData.TryDequeue(out buffer))
                {
                    sslStream.BeginWrite(buffer, 0, buffer.Length, WriteCallback, sslStream);
                }
                else
                {
                    lock (writePendingData)
                    {
                        sendingData = false;
                    }
                }
            }
            catch (Exception ex)
            {
                // handle exception then
                lock (writePendingData)
                {
                    sendingData = false;
                }
            }            
        }
        void WriteCallback(IAsyncResult ar)
        {
            SslStream sslStream = (SslStream)ar.AsyncState;
            try
            {
                sslStream.EndWrite(ar);
            }
            catch (Exception ex)
            {
                // handle exception                
            }
            Write(sslStream);
        }
