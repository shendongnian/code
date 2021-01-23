    //StringWriter
	protected override void Dispose(bool disposing)
	{
		this._isOpen = false;
		base.Dispose(disposing);
	}
	//TextWriter
	protected virtual void Dispose(bool disposing)
	{
	}
