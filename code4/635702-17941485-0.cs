	public NameValueCollection Coll
	{
		get
		{
			var nvc = new NameValueCollection();
			CollDictionary.Keys.ToList().ForEach(a => nvc.Add(a, CollDictionary[a]));
			return nvc;
		}
		set
		{
			CollDictionary = value.AllKeys.ToDictionary(k => k, k => value[k]);
		}
	}
	[JsonProperty(PropertyName = "Coll")]
	public Dictionary<string, string> CollDictionary { get; set; }
