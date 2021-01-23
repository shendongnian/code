    if (m_client.Client.Poll(1000, SelectMode.SelectRead) 
    && (m_client.Client.Available == 0))
    {
    	// Connection has gone - reconnect!
        m_client = new TcpClient(AddressFamily.InterNetwork);
        m_client.Connect(ipAddress, ipPort);
    }
    else
    {
    	// Connection is good, nothing to do
    }
