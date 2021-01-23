	[TestFixture(typeof(Implementation1))]
	[TestFixture(typeof(Implementation2))]
	public class RootSearchAlgorithmsTests<T> where T : ISearchAlgorithm, new()
	{
		private readonly ISearchAlgorithm _searchAlgorithm;
		[SetUp]
		public void SetUp()
		{
			_searchAlgorithm = new T();
		}
		[Test]
		public void TestCosFound()
		{
			// arrange
			// act with _searchAlgorithm
			// assert
		}
		[Test]
		public void TestCosNotFound()
		{
			// arrange
			// act with _searchAlgorithm
			// assert
		} 
		// etc
	}
