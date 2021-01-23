	public Person
	{
		private string name;
		public Person(Name name)
		{
			this.name = name;
		}
		
		public override bool Equals(Object obj)
		{
			if(obj == null)
				return false // not equal if obj is null
				
			Equals temp = obj as Equals; // temp set to null if obj can not be cast to equals
			if(p == null)
				return false
			
			// if code gets here, the code object passed is an instance of Equals.
			// Now we have to check if the strings match.
			bool isEqual = p.name == this.name; // set if the two names match
			return isEqual; // return if these two match
		}
	}
