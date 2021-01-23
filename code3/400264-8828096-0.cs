	private SomeType _someProperty = null;
	public override SomeType SomeProperty
	{
		get
		{
			if (_someProperty == null)
			{
				// Load _someProperty
			}
			return _someProperty;
		}
	}
