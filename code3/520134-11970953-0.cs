	public bool IsDefault<T>(T value)
	{
		if(value == null) return true;
		return value.Equals(default(T));
	}
	int v = 5;
	object o = null;
	IsDefault(v); //False
	IsDefault(0); //True
	IsDefault(o); //True
	IsDefault("ty"); //False
