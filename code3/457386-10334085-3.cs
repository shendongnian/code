	[TestMethod]
	public void TestDivideSubArrays()
	{
		//tests are grouped, alternating a bias between odd/even (left/right)
		//single items
		TestDivideSubArray(new[] { 0 });
		TestDivideSubArray(new[] { 1 });
		//two items
		TestDivideSubArray(new[] { 0, 1 });
		TestDivideSubArray(new[] { 1, 2 });
		//two identical
		TestDivideSubArray(new[] { 0, 0 });
		TestDivideSubArray(new[] { 1, 1 });
		//two more odd than even
		TestDivideSubArray(new[] { 0, 1, 3, 4, 5, 7 });
		//two more even than odd
		TestDivideSubArray(new[] { 0, 1, 2, 4, 5, 6 });
		//some repeating elements
		TestDivideSubArray(new[] { 0, 1, 2, 3, 3, 4, 4, 4, 5 });
		TestDivideSubArray(new[] { 1, 2, 3, 4, 4, 5, 5, 5, 6 });
		//original tests
		TestDivideSubArray(new[] { 0, 1, 2, 3, 4, 5, 6 });
		TestDivideSubArray(new[] { -1, 0, 1, 2, 3, 4, 5 });
	}
