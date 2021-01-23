	public IMyInterface CallBackObject { set; }
	public void Something()
	{
	    obj.CallBackObject = someObject;
	}
	if(CallBackObject != null)
	    CallBackObject.CallBack(1, 2);
