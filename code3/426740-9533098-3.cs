    private static void CreateServer()
    {
        var tcp = new TcpListener(IPAddress.Any, 25565);
        tcp.Start();
    
        var listeningThread = new Thread(() =>
        {
            while (true)
            {
                var tcpClient = tcp.AcceptTcpClient();
                ThreadPool.QueueUserWorkItem(param =>                                                            
                {                        
                    NetworkStream stream = tcpClient.GetStream();
                    string incomming;                        
                    byte[] bytes = new byte[1024];
                    int i = stream.Read(bytes, 0, bytes.Length);                                                
                    incomming = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    form.console.Invoke(
                    (MethodInvoker)delegate
                        {
                            form.console.Text += String.Format(
                                "{0} Connection esatblished: {1}{2}", 
                                DateTime.Now,
                                tcpClient.Client.RemoteEndPoint,
                                Environment.NewLine);
                        });
    
                    MessageBox.Show(String.Format("Received: {0}", incomming));
                    form.incommingMessages.Invoke((MethodInvoker)(() => form.incommingMessages.Items.Add(incomming)));
                    tcpClient.Close();
                }, null);
            }
        });
    
        listeningThread.IsBackground = true;
        listeningThread.Start();
    }
