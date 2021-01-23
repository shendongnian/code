    public Guid CreateSequentialUuid()
    {
    	var ticksAsBytes = BitConverter.GetBytes(currentEtagBase);
    	Array.Reverse(ticksAsBytes);
    	var increment = Interlocked.Increment(ref sequentialUuidCounter);
    	var currentAsBytes = BitConverter.GetBytes(increment);
    	Array.Reverse(currentAsBytes);
    	var bytes = new byte[16];
    	Array.Copy(ticksAsBytes, 0, bytes, 0, ticksAsBytes.Length);
    	Array.Copy(currentAsBytes, 0, bytes, 8, currentAsBytes.Length);
    	return bytes.TransfromToGuidWithProperSorting();
    }
