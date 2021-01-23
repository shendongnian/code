	public TInterface Instantiate<TInterface>(Type type)
	{
		if (!typeof(TInterface).IsAssignableFrom(type))
			throw new Exception("Wrong type!");
		return (TInterface)Instantiate(type);
	}
	
