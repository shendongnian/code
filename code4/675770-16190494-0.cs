	if (hipDepthPoint.X < 100)
	{
		Xvariabel = 1;
	}
	else 
	{
		Xvariabel = 2;
	}
	public int Xvariabel 
	{
		get { return _xvariabel ; }
		set
		{
			if (_xvariabel != value)
			{
				_xvariabel = value
				//do some action
			}
		}
	}
