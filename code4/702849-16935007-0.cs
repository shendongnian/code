	public void DoSomething( .... , bool orderByX)
	{
		foreach( ... OrderBy(x => orderByX ? x.Location.X : x.Location.Y))
		{
		  ...
		}
	}
