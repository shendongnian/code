    void StartListener()
    {
    	System.Threading.Thread listenerThread = new System.Threading.Thread(ListenerThread));
        listenerThread.IsBackground = true; // Causes the thread to close if the app is closed
    	listenerThread.Start();
    }
    
    void ListenerThread()
    {
    	TcpListener tcp = new TcpListener(IPAddress.Parse("192.168.1.66"),9000);
    	tcp.Start();
    	UpdateStatus("Start Listening \r\n"); //1
    	Socket s = tcp.AcceptSocket();
    	UpdateStatus("Client Has Connected \r\n"); //1
  
        // Listen for more messages, or close the listener here.
    }
    
    void UpdateStatus(string message)
    {
    	if(InvokeRequired)
    		Invoke((MethodInvoker)delegate { UpdateStatus(message); });
    	else
    		Textbox.Text = message;
    }
