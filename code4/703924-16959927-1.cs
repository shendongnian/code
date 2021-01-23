	public virtual int Age { 
		get
		{
			if (!Dob.HasValue)
			{
				throw new Exception(); // ?
				return -1; // ?
			}
			
			return CalculateAge(Dob.Value);
		}
	}
