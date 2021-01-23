	public object Object
	{
		get { return this.GetObject(); }
	}
	private object GetObject()
	{
		var value = this.OnGetObject();
		this.isInitialized = true;
		return value;
	}
