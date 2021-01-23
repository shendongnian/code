	public class Foo {
		private static Action pLambda, qLambda;
		
		private int x;
		private void p()
		{
			Foo.pLambda = new Action(Foo.<p>b__0);
		}
		private void q()
		{
			Foo.qLambda = new Action(this.<q>b__2);
		}
		[CompilerGenerated] private static void <p>b__0()
		{
			Console.WriteLine("Simple lambda!");
		}
		[CompilerGenerated] private void <q>b__2()
		{
			Console.WriteLine(this.x);
		}
		// (I don't know why this is here)
		[CompilerGenerated] private static Action CS$<>9__CachedAnonymousMethodDelegate1;
	}
