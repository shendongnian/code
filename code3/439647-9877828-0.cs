    public static AssertEqualSetCaseInsensitive(this IEnumerable<string> actual, IEnumerable<string> expected)
    {
       if (actual.Count() != expected.Count())
          Assert.Fail("not same number of elements");
    
       if (!actual.All(a => expected.Any(e => e.ToLower() == a.ToLower()))
          Assert.Fail("not same sets");
    }
