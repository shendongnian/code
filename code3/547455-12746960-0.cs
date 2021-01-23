    private static object syncRoot = new Object();
    private Bitmap _bm;
    private Bitmap bm
    {
    	get
    	{
    		lock (syncRoot)
    			return this._bm.DeepClone();
    	}
    	set
    	{
    		lock (syncRoot)
    		{
    			this._bm = value.DeepClone();
    		}
    	}
    }
