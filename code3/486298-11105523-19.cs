	internal class Foo
	{
		private static Action fLambda;
		private static Action gLambda;
		private int x;
		private void f()
		{
			Foo.<>c__DisplayClass1 <>c__DisplayClass = new Foo.<>c__DisplayClass1();
			<>c__DisplayClass.y = 0;
			Foo.fLambda = new Action(<>c__DisplayClass.<f>b__0);
		}
		private void g()
		{
			Foo.<>c__DisplayClass4 <>c__DisplayClass = new Foo.<>c__DisplayClass4();
			<>c__DisplayClass.<>4__this = this;
			<>c__DisplayClass.y = 0;
			Foo.gLambda = new Action(<>c__DisplayClass.<g>b__3);
		}
		[CompilerGenerated]
		private sealed class <>c__DisplayClass1
		{
			public int y;
			public void <f>b__0()
			{
				this.y++;
			}
		}
		[CompilerGenerated]
		private sealed class <>c__DisplayClass4
		{
			public int y;
			public Foo <>4__this;
			public void <g>b__3()
			{
				this.y += this.<>4__this.x;
			}
		}
	}
