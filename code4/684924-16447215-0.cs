    void StartListener()
    {
    	System.Threading.Thread listenerThread = new System.Threading.Thread(ListenerThread));
    	listenerThread.Start();
    }
    
    void ListenerThread()
    {
    	TcpListener tcp = new TcpListener(IPAddress.Parse("192.168.1.66"),9000);
    	tcp.Start();
    	UpdateStatus("Start Listening \r\n"); //1
    	Socket s = tcp.AcceptSocket();
    	UpdateStatus("Client Has Connected \r\n"); //1
    }
    
    void UpdateStatus(string message)
    {
    	if(InvokeRequired)
    		Invoke((MethodInvoker)delegate { UpdateStatus(message); });
    	else
    		Textbox.Text = message;
    }
