    private ManualResetEventSlim _myLock = new ManualResetEventSlim(true);
    
    private void sendToCOM(String comNumber, String msg, String speed)
    {
    	_myLock.Wait();
    	try
    	{
    		_myLock.Reset();
    		using (SerialPort comPort = new SerialPort(comNumber, Int32.Parse(speed), Parity.None, 8, StopBits.One))
    		{
    			// ..
    		}
    	}
    	catch(Exception ex)
    	{
    		cstFuncs.errorHandler(ex.Message, SettingsForm);
    	} 
    	finally
    	{
    		_myLock.Set();
    	}
    }
