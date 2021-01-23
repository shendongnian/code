    public void Run()
    {
    	 byte[] data;
    	 try
    	 {
    		using (var r = new StreamReader("c:/myfile2.txt"))
    		{
    			string line ="";
    			int lineNumber = 0;
    			while (null != (line = r.ReadLine()))
    			{
    				data = Encoding.ASCII.GetBytes(line + "\n");
    				_client.Client.Send(data, data.Length, SocketFlags.None);
    			}
    		}
    	 }
    	 catch (Exception ex)
    	 {
    		 Console.Error.WriteLine(ex.ToString());
    	 }
    	 Console.WriteLine("Closing client");
    	 _client.Close();
    }
