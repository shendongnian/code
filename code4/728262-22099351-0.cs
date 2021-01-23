	public abstract class BaseClass
	{
		[SetUp]
		public void BaseSetUp()
		{
			Debug.WriteLine("BaseSetUp Called")
		}
	}
	[TestFixture]
	public class DerivedClass : BaseClass
	{
		[SetUp]
		public void DerivedSetup()
		{
			Debug.WriteLine("DerivedSetup Called")	
		}
		[Test]
		public void SampleTest()
		{
			/* Will output
			 *    BaseSetUp Called
			 *    DerivedSetup Called
			*/
		}
	}
