        // Is not changed
        public static Task<int> ReceiveAsync(this Socket socket, byte[] buffer, int offset, int size, SocketFlags flags = SocketFlags.None)
        {
            if (socket == null) throw new Exception("Socket is null.");
            var tcs = new TaskCompletionSource<int>(socket);
            socket.BeginReceive(buffer, offset, size, flags, iar =>
            {
                var t = (TaskCompletionSource<int>)iar.AsyncState;
                var s = (Socket)t.Task.AsyncState;
                try { t.SetResult(s.EndReceive(iar)); }
                catch (Exception exc) { t.SetException(exc); }
            }, tcs);
            return tcs.Task;
        }
        // Moved to new function
        public void PerformRead()
        {
            while ((byteRead = ReceiveAsync(socket, buffer, 0, buffer.Length, SocketFlags.None).Result) > 0)
            {
               lock (buffer)
               {
                   try
                   {
                      byte[] dBuffer = decompressor.Decompress(buffer);
                      lock (dBuffer)
                      {
                          string receivedData = Encoding.UTF8.GetString(dBuffer);
                          OnRead(receivedData, byteRead);
                      }
                   }
                   catch (Exception ex)
                   {
                      Client.Base.Log.Save(ex);
                      socket.Shutdown(SocketShutdown.Both);
                   }
               }
            }
        }
