    internal static class MyAssert
    {
	public static void AreEquivalent<T>(IEnumerable<T> enumerable1, IEnumerable<T> enumerable2)
	{
		bool val = false;
		if (enumerable2 == null)
		{
			val = !enumerable1.Any();
			if (val == false)
			{
				Assert.Fail("enumerable2 is empty, enumerable1 is not");
			}
		}
		else if (enumerable1 == null)
		{
			val = !enumerable2.Any();
			if (val == false)
			{
				Assert.Fail("enumerable1 is empty, enumerable2 is not");
			}
		}
		else
		{
			var list1 = enumerable1.ToList();
			var list2 = enumerable2.ToList();
			if (list1.Count != list2.Count)
			{
				Assert.Fail("Count result is not the same");
			}
			if (list1.Intersect(list2).Count() != list2.Count())
			{
				Assert.Fail("count of Intersect enumerable1 is not the same as enumerable2 count");
			}
		}
	}
    }
