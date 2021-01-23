    public void Stop()
    {
         if (!Listening)
         {
              return;
         }
         s.Close();
         s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
         Listening = false; //Set Listening to False to start the socket again
    }
