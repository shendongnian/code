    `protected override void OnStart(string[] args)
    {
            tcpServerStart(); 
    }
	private void tcpServerStart()
	{
		try
		{
			IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            //port 5555, or any port number you want
			listener = new TcpListener(ipAddress, 5555);  
			listener.Start();
			var whileThread = new Thread(() =>
			{
				while (true)
				{
					// in order to avoid while loop turn into an infinite loop, 
                    // we have to use AcceptTcpClient() to block it.
					TcpClient client = listener.AcceptTcpClient(); 
					
					// for each connection we just fork a thread to handle it.
					var childThread = new Thread(() =>
					{
						// Get a stream object for reading and writing
						NetworkStream stream = client.GetStream(); // not blocking call
						StreamReader streamreader = new StreamReader(client.GetStream(), Encoding.ASCII);
						string line = null;
						
						// below while loop is your logic code, change it to your needs.
                        // defined "<EOF>" as mine quit message 
						while ((line = streamreader.ReadLine()) != "<EOF>") 
						{
                         // WriteToFile is a function of mineto log system status
							WriteToFile(line); 
						}
						stream.Close();
						client.Close();
					});
					childThread.Start();
				} // end of while(true) loop
			});
			whileThread.Start();
		}
		catch (Exception e)
		{
		}
	}  '  
