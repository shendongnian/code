	public void BeginOutputRead()
	{
	  [..]
	  if (this.output == null)
	  {
	    [..]                    
	    this.output = new AsyncStreamReader(this, baseStream, new UserCallBack(this.OutputReadNotifyUser), this.standardOutput.CurrentEncoding);
	  }
	}
	public void Start()
	{	
		this.Close();
		[..]
	}
	public void Close()
	{	
		[..]
		this.output = null;
		this.error = null;
		[..]
	}
