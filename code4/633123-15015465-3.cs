	public object this[Variables v]
	{
		get { return getVariable(v); /* or move implementation here */ }
		set { serVariable(v, value); /* or move implementation here */ }
	}
