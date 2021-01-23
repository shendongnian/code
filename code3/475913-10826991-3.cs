	public interface IBar
	{
	}
	public class Bar : IBar
	{
		public override bool Equals(object obj)
		{
			return false;
		}
	}
	[TestClass]
	public class Class1
	{
		[TestMethod]
		public void TestMoq()
		{
			var a = new Mock<Bar>();
			var b = new Mock<Bar>();
			a.Setup(bar => bar.Equals(b.Object)).Returns(true);
			Assert.IsTrue(a.Object.Equals(b.Object));
		}
	}
