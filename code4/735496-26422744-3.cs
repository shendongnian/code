    namespace MyNamespace
    {
    
    class MySerial
    {
    	///A condition variable that signals when serial has a data. Used together with the next
    	///one «SerHasData» internally.
    	private System.Object SerialIncoming;
    
    	public MySerial()
    	{
    		SerialIncoming = new Object();
    	}
    
    	/**
    	 * A proxy function that will be called every time a data arrived
    	 */
    	private void Proxy(Object unused1, SerialDataReceivedEventArgs unused2)
    	{
    		Console.WriteLine("Data arrived!");
    		lock (SerialIncoming)
            {
                Monitor.Pulse(SerialIncoming);
            }
    	}
    
    	/**
    	 * Waits for a data for the time interval Timeout
    	 * \param Timeout a timeout in milliseconds to wait for a data
    	 * \returns true in if a data did arrived, and false else
    	 */
    	public bool WaitForAData(int Timeout)
    	{
    		lock (SerialIncoming)//waits N seconds for a condition variable
            {
                if (!Monitor.Wait(SerialIncoming, Timeout))
    				{//if timeout
    					Console.WriteLine("Time out");
    					return false;
    				}
                return true;
            }
    	}
    
    	/* Just a test function: opens a serial with speed, and waits
    	 * for a data for the «Timeout» milliseconds.
    	 */
    	public void TestFunc(string serial, int speed, int Timeout)
    	{
    		SerialPort ser = new SerialPort(serial);
    		ser.BaudRate = speed;
    		ser.DataReceived += Proxy;
    		ser.Open();
    		if (WaitForAData(Timeout))
    			Console.WriteLine("Okay in TestFunc");
    		else
    			Console.WriteLine("Time out in TestFunc");
    	}
    }
    
    }
