    private static void CreateServer()
    {
        TcpListener tcp = new TcpListener(IPAddress.Any, 25565);
        tcp.Start();
    
        Thread t = new Thread(() =>
        {
    
            while (true)
            {
                var tcpClient = tcp.AcceptTcpClient();
    
                ThreadPool.QueueUserWorkItem((_) =>                                                            
                {                        
                    NetworkStream stream = tcpClient.GetStream();
                    string incomming = String.Empty;
                            
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
                    form.incommingMessages.Invoke((MethodInvoker)delegate { form.incommingMessages.Items.Add(incomming); });
    
                    byte[] outMsg = System.Text.Encoding.ASCII.GetBytes(incomming);
    
                    // Send back a response.
                    stream.Write(outMsg, 0, outMsg.Length);
    
                    tcpClient.Close();
                }, null);
            }
        });
    
        t.IsBackground = true;
        t.Start();
    }
