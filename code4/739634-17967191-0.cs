    private string ReadFromSerial()
    {
    	try
    	{
    		System.IO.Ports.SerialPort Serial1 = new System.IO.Ports.SerialPort("COM1", 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
    		Serial1.DtrEnable = true;
    		Serial1.RtsEnable = true;
    		Serial1.ReadTimeout = 3000;
    
    		var MessageBufferRequest = new byte[8] { 1, 3, 0, 28, 0, 1, 69, 204 };
    		var MessageBufferReply = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
    		int BufferLength = 8;
    		
    		if (!Serial1.IsOpen)
    		{
    			Serial1.Open();
    		}
    		
    		try
    		{
    			Serial1.Write(MessageBufferRequest, 0, BufferLength);
    		}
    		catch (Exception ex)
    		{
    			logEx(ex);
    			return "";
    		}
    	 
    		System.Threading.Thread.Sleep(100);
    		
    		Serial1.Read(MessageBufferReply, 0, 7);
    
    		return MessageBufferReply[3].ToString();
    	}
    	catch (Exception ex)
    	{
    		logEx(ex);
    		return "";
    	}
    }
