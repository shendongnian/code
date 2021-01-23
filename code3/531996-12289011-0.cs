    RangeBase range = collection.FirstOrDefault(x => x.BelongsToRange(42));
	if(range != null)
	{
		dynamic result = range.SomeDelegate.DynamicInvoke();
	}
