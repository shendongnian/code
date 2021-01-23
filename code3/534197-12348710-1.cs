	public string Name 
	{
		get { return lcl_name; }
		set 
		{
			if (lcl_name != value) 
			{
				lcl_name = value;
				// Foo_Method("Foo"); string is bad
				Foo_Method(x => x.Name);
			}
		}	
	}
