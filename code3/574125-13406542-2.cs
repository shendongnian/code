   
     void Run()
     {
         TcpListener listener = new TcpListener(IPAddress.Any, 12345);
         listener.Start();
     
        Task.Factory.StartNew(() =>
        {
            while (true)
            {
                var client = listener.AcceptTcpClient();
                Task.Factory.StartNew(() => Handler(client), TaskCreationOptions.LongRunning);
            }
        }, TaskCreationOptions.LongRunning);
     }
     
     void Handler(TcpClient client)
     {
         using (NetworkStream stream = client.GetStream())
         {
             var dataBuffer = new Byte[256];
             int i;
             while ((i = stream.Read(dataBuffer, 0, dataBuffer.Length)) != 0)
             {
                 // Processes data here..
                 //var s = Encoding.UTF8.GetString(dataBuffer, 0, i);
                 //Console.Write(s);
     
             }
         }
     }
