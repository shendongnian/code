	public class Test
	{
		public void MockObject()
		{
			var mocked = new Moq.Mock<MyDependency>();
			mocked.CallBase = true;
			mocked.Setup(m => m.Outputs).Returns(new Dictionary<string, object>() { { "key", "value" } });
			mocked.Object.{do something with mocked object};
		}
	}
