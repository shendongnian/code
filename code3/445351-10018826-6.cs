	public int Foo
	{
		get
		{
			return GetHelper<int>("foo");
		}
		set
		{
			Session["foo"] = value;
		}
	}
	public T GetHelper<T>(string name, T defaultValue = default(T))
	{
		if (Session[name] != null)
			return (T)Session[name];
		else
		{
			return defaultValue;
		}
	}
