    public void CopyTo(Stream destination)
    {
    	// ... a bunch of argument validation stuff (omitted)
    	this.InternalCopyTo(destination, 81920);
    }
    private void InternalCopyTo(Stream destination, int bufferSize)
    {
    	byte[] array = new byte[bufferSize];
    	int count;
    	while ((count = this.Read(array, 0, array.Length)) != 0)
    	{
    		destination.Write(array, 0, count);
    	}
    }
