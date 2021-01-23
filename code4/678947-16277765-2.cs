	[TestMethod]
	public void TestMethod1()
	{
		var list = new[] { "z", "u", "first", "b", "a" }.OrderByPredicateFirst(s => s == "first").ToList();
		Assert.AreEqual("first", list[0]);
		Assert.AreEqual("a", list[1]);
		Assert.AreEqual("b", list[2]);
		Assert.AreEqual("u", list[3]);
		Assert.AreEqual("z", list[4]);
	}
    public static class Extensions
    {
        public static IEnumerable<T> OrderByPredicateFirst<T>(this IEnumerable<T> source, Predicate<T> firsts)
        {
            return source
              .OrderBy(s => firsts(s) ? 0 : 1)
              .ThenBy(s => s);
        }
    }
