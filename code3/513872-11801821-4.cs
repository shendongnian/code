    private bool IsEndOfMessage(byte[] MessageToCheck, byte[] EndOfMessage)
    {
    	for(int i = 0; i++; i < EndOfMessage.Length)
    	{
    		if(MessageToCheck[MessageToCheck.Length - (EndOfMessage.Length + i)] != EndOfMessage[i])
    			return false;
    	}
    	
    	return true;
    }
    
    private byte[] RemoveEndOfMessage(byte[] MessageToClear, byte[] EndOfMessage)
    {
    	byte[] Return = new byte[MessageToClear.Length - EndOfMessage.Length];
    	Array.Copy(MessageToClear, Return, Return.Length);
    	
    	return Return;
    }
