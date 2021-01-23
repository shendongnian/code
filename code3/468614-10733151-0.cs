	class MyObject
	{
		public Guid Id { get; set; }
		public override bool Equals(object other)
		{
			MyObject myObj = obj as MyObject;
			if (myObj != null)
			{
				// use the 'Id' property as identifier
				return myObj.Id == this.Id;
			}
			// is not a 'MyObject' based object
			return base.Equals(other);
		}
	}
