	public void SetValueOverride(T value)
	{
		ValueGetter = () => value;
	}
	
	public void RemoveOverride()
	{
		ValueGetter = OriginalValueGetter;
	}
