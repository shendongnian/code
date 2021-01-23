	public void TestDivideSubArray(int[] ints)
	{
		int numOdd = ints.Count(i => (i % 2) != 0);
		Console.WriteLine("Before:\t{0}", string.Join(", ", ints));
		//not optimal, but this is just a test
		int[] expectedLeft = ints.Where(i => (i % 2) != 0).ToArray();
		int[] expectedRight = ints.Where(i => (i % 2) == 0).ToArray();
		DivideSubArray(ints, 0, numOdd, numOdd, ints.Length - numOdd);
		Console.WriteLine("After:\t{0}", string.Join(", ", ints));
		Console.WriteLine();
		Assert.IsTrue(expectedLeft.SequenceEqual(ints.Take(numOdd)));
		Assert.IsTrue(expectedRight.SequenceEqual(ints.Skip(numOdd)));
	}
