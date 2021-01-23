    Thread t = new Thread(
       o => 
       {
        while (true)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IAsyncResult result = socket.BeginConnect("192.168.0.131", 1095, null, null);
            bool success = result.AsyncWaitHandle.WaitOne(500, true);
            if (!socket.Connected)
            {
                
                label3.BeginInvoke((Action)(() => { label3.Text = "can't use"; }));
                socket.Close();
            }
            else
            {
                //success = true;
                label3.BeginInvoke((Action)(() => { label3.Text = "start action"; }));
                socket.Close();
            }
        }
      });
    t.Start();
