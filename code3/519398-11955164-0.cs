    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct MLocation
    {
    	public int x;
    	public int y;
    };
    
    public static void Main()
    {
    	MLocation test = new MLocation();
    
    	// Gets size of struct in bytes
    	int structureSize = Marshal.SizeOf(test);
    
    	// Builds byte array
    	byte[] byteArray = new byte[structureSize];
    
    	IntPtr memPtr = IntPtr.Zero;
    
    	try
    	{
    		// Allocate some unmanaged memory
    		memPtr = Marshal.AllocHGlobal(structureSize);
    
    		// Copy struct to unmanaged memory
    		Marshal.StructureToPtr(test, memPtr, true);
    
    		// Copies to byte array
    		Marshal.Copy(memPtr, byteArray, 0, structureSize);
    	}
    	finally
    	{
    		if (memPtr != IntPtr.Zero)
    		{
    			Marshal.FreeHGlobal(memPtr);
    		}
    	}
    
    	// Now you can send your byte array through TCP
    	using (TcpClient client = new TcpClient("host", 8080))
    	{
    		using (NetworkStream stream = client.GetStream())
    		{
    			stream.Write(byteArray, 0, byteArray.Length);
    		}
    	}
    
    	Console.ReadLine();
    }
