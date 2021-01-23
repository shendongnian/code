	private int _x;
	public int X
	{
		get { return _x; }
		set
		{
			if (!CanSetXyz)
			{
				throw new CantSetXyzException("Can't set X on a Normal point.");
			}
			_x = value;
		}
	}
