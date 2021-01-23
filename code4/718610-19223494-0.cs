    //01. Declare 'Command' structure
    public struct Command
    {
    	public byte CommandCode;
    	public byte ParameterCode;
    	public struct Data
    	{
    		public uint Size;
    		public IntPtr Body;
    	}
    	public Data SendData;
    }    
    
    //02. Create & assign an instance of 'Command' structure 
    //Create body array
    byte[] body = { 0x33, 0x32, 0x34, 0x31, 0x30 };
    
    //Get IntPtr from byte[] (Reference: http://stackoverflow.com/questions/537573/how-to-get-intptr-from-byte-in-c-sharp)
    GCHandle pinnedArray = GCHandle.Alloc(body, GCHandleType.Pinned);
    IntPtr pointer = pinnedArray.AddrOfPinnedObject();
    
    //Create command instance
    var command = new CardReaderLib.Command
    				  {
    					  CommandCode = 0x30,
    					  ParameterCode = 0x30,
    					  SendData = {
    						  Size = (uint) body.Length, 
    						  Body = pointer
    					  }
    				  };
    
    //do your stuff
    if (pinnedArray.IsAllocated)
		pinnedArray.Free();
