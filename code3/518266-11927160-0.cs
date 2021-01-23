    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IAsyncResult result = socket.BeginConnect(_ip, Port, null, null);
        bool success = result.AsyncWaitHandle.WaitOne(500, true); // 500 is milisecods to wait
         if (socket.Connected && socket.IsBound && success)
         {
              // do your work                          
         }else
        {
         // open a new connection or show your message to user
        }
