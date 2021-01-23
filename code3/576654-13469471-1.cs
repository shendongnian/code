	[TestFixture]
	public class FactorialTests
	{
		[TestCase(0, 1)]
		[TestCase(1, 1)]
		[TestCase(2, 2)]
		[TestCase(7, 5040)]
		[TestCase(10, 3628800)]
		public void Compute_ReturnsCorrectResult(int n, int expectedResult)
		{
			var sut = new Factorial();
			Assert.AreEqual(expectedResult, sut.Compute(n));
		}
	}
