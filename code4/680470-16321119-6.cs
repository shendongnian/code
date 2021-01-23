	public T Value
	{
		get 
		{
			return ValueGetter();
		}
		set
		{
			if (value == null)
				ValueGetter = OriginalValueGetter;
			else
				ValueGetter = () => value;
		}
	}
	myThing = _thingManualOverride.Value; //Thing1
	_thingManualOverride.Value = new Thing2();
	myThing = _thingManualOverride.Value; //Thing2
	_thingManualOverride.Value = null;
	myThing = _thingManualOverride.Value; //Thing1 ... not null!?
