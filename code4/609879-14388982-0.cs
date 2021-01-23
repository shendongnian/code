	[ConfigurationProperty("", IsDefaultCollection = true)]
	[ConfigurationCollection(typeof(MyElementCollection), AddItemName = "element")]
	public MyElementCollection Elements
	{
		get { return (MyElementCollection)this[""];
	}
