	private List<Bar> barsList = new List<Bar>(){ b1, b2, b3 };
	
	public void UpdateBarsMyProp(bool value)
    {
        foreach(Bar bar in barsList)
		{
			bar.MyProp = value;
		}
    }
