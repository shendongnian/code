    public void Close()
    {
    	if (DisposableMember != null)
    	{
    		DisposableMember.Dispose();
    		DisposableMember = null;
    	}
    }
