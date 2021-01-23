    public IDictionary<string,MyClass1> GetProperty1()
    {
		if ( _property1 == null )
		{
			_property1 = LoadFromDatabase();
		}
		return _property1;
    }
