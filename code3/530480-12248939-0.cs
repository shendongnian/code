    public delegate void ProgressChangedEvHandler(int progress);
    
    public event ProgressChangedEvHandler ProgressChanged;
    
    private void OnProgressChanged(int progress)
    {
    	var handler = ProgressChanged;
    	if (handler != null) handler(progress);
    }
