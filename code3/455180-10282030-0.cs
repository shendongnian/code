	[XmlElement("AnyType")]
	public object[] itemsSerializable
	{
		get { return items.ToArray(); }
		set { items = new ArrayList(value); }
	}
		
	[XmlIgnore]
	public ArrayList items
	{
		get;
		set;
	}
