		[TestMethod]
		public void TestFieldVsProperty()
		{
			const int COUNT = 0x7fffffff;
			A a1 = new A();
			A a2 = new A();
			B b1 = new B();
			B b2 = new B();
			C c1 = new C();
			C c2 = new C();
			D d1 = new D();
			D d2 = new D();
			Stopwatch sw = new Stopwatch();
			
			long t1, t2, t3, t4;
			sw.Restart();
			for (int i = COUNT - 1; i >= 0; i--)
			{
				a1.P = a2.P;
			}
			sw.Stop();
			t1 = sw.ElapsedTicks;
			sw.Restart();
			for (int i = COUNT - 1; i >= 0; i--)
			{
				b1.P = b2.P;
			}
			sw.Stop();
			t2 = sw.ElapsedTicks;
			sw.Restart();
			for (int i = COUNT - 1; i >= 0; i--)
			{
				c1.P = c2.P;
			}
			sw.Stop();
			t3 = sw.ElapsedTicks;
			sw.Restart();
			for (int i = COUNT - 1; i >= 0; i--)
			{
				d1.P = d2.P;
			}
			sw.Stop();
			t4 = sw.ElapsedTicks;
			long max = Math.Max(Math.Max(t1, t2), Math.Max(t3, t4));
			Console.WriteLine($"auto: {t1}, {max * 100d / t1:00.00}%.");
			Console.WriteLine($"field: {t2}, {max * 100d / t2:00.00}%.");
			Console.WriteLine($"manual: {t3}, {max * 100d / t3:00.00}%.");
			Console.WriteLine($"no inlining: {t4}, {max * 100d / t4:00.00}%.");
		}
		class A
		{
			public double P { get; set; }
		}
		class B
		{
			public double P;
		}
		class C
		{
			private double p;
			public double P
			{
				get => p;
				set => p = value;
			}
		}
		class D
		{
			public double P
			{
				[MethodImpl(MethodImplOptions.NoInlining)]
				get;
				[MethodImpl(MethodImplOptions.NoInlining)]
				set;
			}
		}
