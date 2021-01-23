	public static class TestClass {
		public static void Take(object o) {
			Console.WriteLine("Received an object");
		}
		public static void Take(int i) {
			Console.WriteLine("Received an integer");
		}
		public static void TestMethod() {
			var a=(object)2;
			Take(a);
			dynamic b=(object)2;
			Take(b);
		}
	}
