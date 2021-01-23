	public static class TestClass {
		public static void TestMethod() {
			var x=new Pretended();
			Console.WriteLine("{0}", x.GetType());
			Console.WriteLine("{0}", (x as object).GetType());
		}
	}
	public partial class Pretended {
		public new Type GetType() {
			return typeof(int);
		}
	}
