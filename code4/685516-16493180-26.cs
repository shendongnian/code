	public partial class TestClass {
		public static void TestMethod() {
			foreach(var type in MartinMulderExtensions.GetDesiredTypes())
				Console.WriteLine(type);
		}
	}
