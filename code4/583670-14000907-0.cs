	public DynamicFile(IDictionary<string, object> dictionary)
	{
		if (dictionary == null)
			throw new ArgumentNullException("dictionary");
		_dictionary = dictionary;
		_lastGetRef = _dictionary;
	}
	private readonly IDictionary<string, object> _dictionary;
	private IDictionary<string, object> _lastGetRef;
	
	public override bool TryGetMember(GetMemberBinder binder, out object result)
	{
		if (!_dictionary.TryGetValue(binder.Name, out result))
		{
			result = null;
			return true;
		}
		var dictionary = result as IDictionary<string, object>;
		if (dictionary != null)
		{
			result = new DynamicFile(dictionary);
			_lastGetRef = dictionary;
			return true;
		}
		
		return true;
	}
	
	public override bool TrySetMember(SetMemberBinder binder, object value)
	{
		if(_dictionary.ContainsKey(binder.Name))
			_dictionary[binder.Name] = value;
		else if (_lastGetRef.ContainsKey(binder.Name))
			_lastGetRef[binder.Name] = value;
		else
			_lastGetRef.Add(binder.Name, value);
		return true;
	}
