	public List<Tuple<SomeType, AnotherType>> TheMethod(SomeParameter)
	{
	  using (MyDC TheDC = new MyDC())
	  {
		 var TheQueryFromDB = (....
							   select Tuple.Create(..., ...)
							   ).ToList();
		  return TheQueryFromDB.ToList();
		}
	}
