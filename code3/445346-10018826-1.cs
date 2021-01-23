	public int Foo
	{
		get
		{
			return GetHelper<int>();
		}
		set
		{
			SetHelper(value);
		}
	}
	public string Bar
	{
		get
		{
			return GetHelper<string>();
		}
		set
		{
			SetHelper(value);
		}
	}
	public T GetHelper<T>(T defaultValue = default(T), [CallerMemberName] string propertyName = "")
	{
		if (Session[propertyName] != null)
			return (T)Session[propertyName];
		else
		{
			return defaultValue;
		}
	}
