	private MyEnum AdjustType(object q)
	{
		#region Contract
		if (q == null)
			throw new ArgumentNullException("q");
		if (q.Value != "M" && q.Value != "N")
			throw new ArgumentException("Value must be M or N.", "q");
		#endregion
		
		// Here all incoming arguments are valid and within range.
		// ...
	}
