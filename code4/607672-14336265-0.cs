    private readonly object _myLock = new object();
    
    private void sendToCOM(String comNumber, String msg, String speed)
    {
    	try
    	{
    		lock(_myLock)
    		{
    			using (SerialPort comPort = new SerialPort(comNumber, Int32.Parse(speed), Parity.None, 8, StopBits.One))
    			{
    				comPort.Open();
    				comPort.Write(msg);
    				comPort.Close();
    				comPort.Dispose();
    			}
    		}
    	}
    	catch(Exception ex)
    	{
    		cstFuncs.errorHandler(ex.Message, SettingsForm);
    	}
    }
