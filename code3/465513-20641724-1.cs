	void Main()
	{
		foreach(var t in typeof(test).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(test))))
			((test)(Activator.CreateInstance(t))).TestMethod();
	}
	
	private abstract class test
	{
		public abstract void TestMethod();
	}
	
	private class test1 : test
	{
	
		delegate Action<T> Continuation<T>(Continuation<T> r);
		
		//[TestMethod]
		//The fixed point operator, very slow also.
		public override void TestMethod()
		{
			IObject root = BuildComposite();
	
			Performance.Measure(1000000, () =>
			{
				Apply(root, h => t =>
				{
					foreach (IObject item in t.Children)
					{
						//Console.WriteLine(item.Name);
						h(item);
					}
				});
			}, "Time " + this.GetType().Name);
		}
	
		private static void Apply(IObject root, Func<Action<IObject>, Action<IObject>> g)
		{
			Continuation<IObject> action = c => thing => { g(c(c))(thing); };
	
			Action<IObject> target = action(action);
	
			target(root);
		}
		
	}
	
	private class test2 : test
	{
		
		delegate void Continuation<T>(Continuation<T> r, T n);
	
		//[TestMethod]
		//Without curry, curring makes things go slow.
		public override void TestMethod()
		{
			var root = BuildComposite();
	
			Performance.Measure(1000000, () =>
			{
				Apply(root, (c, thing) =>
				{
					foreach (var item in thing.Children)
					{
						//Console.WriteLine(item.Name);
						c(c, item);
					}
				});
			}, "Time " + this.GetType().Name);
		}
	
		void Apply(IObject root, Continuation<IObject> f)
		{
			f(f, root);
		}
			
	}
	
	private class test3 : test
	{
	
		//[TestMethod]
		//Another common definition found on web, this is worse of then all.
		//http://stackoverflow.com/questions/4763690/alternative-y-combinator-definition
		public override void TestMethod()
		{
			var root = BuildComposite();
	
			Performance.Measure(1000000, () =>
			{
				Y<IObject, int>(f => thing =>
				{
					foreach (var item in thing.Children)
					{
						//Console.WriteLine(item.Name);
						f(item);
					}
					return 0;
				})(root);
			}, "Time " + this.GetType().Name);
		}
		
		public delegate TResult SelfApplicable<TResult>(SelfApplicable<TResult> r);
		
		public static TResult U<TResult>(SelfApplicable<TResult> r)
		{
			return r(r);
		}
		
		public static Func<TArg1, TReturn> Y<TArg1, TReturn>(Func<Func<TArg1, TReturn>, Func<TArg1, TReturn>> f)
		{
			return U<Func<TArg1, TReturn>>(r => arg1 => f(U(r))(arg1));
		}
			
	}
	
	private class test4 : test
	{
	
		//[TestMethod]
		//Simpler definition, taken from this SO.
		//This uses inherent compiler recursion, lets see if it speed things up.
		//http://stackoverflow.com/questions/4763690/alternative-y-combinator-definition
		public override void TestMethod()
		{
			var root = BuildComposite();
	
			Performance.Measure(1000000, () =>
			{
				Y<IObject, int>(f => thing =>
				{
					foreach (var item in thing.Children)
					{
						//Console.WriteLine(item.Name);
						f(item);
					}
					return 0;
				})(root);
			}, "Time " + this.GetType().Name);
		}
		
		public static Func<TArg1, TReturn> Y<TArg1, TReturn>(Func<Func<TArg1, TReturn>, Func<TArg1, TReturn>> f)
		{
			return f(n => Y(f)(n));
		}
			
	}
	
	private class test5 : test
	{
	
		//[TestMethod]
		//Simple way to recurse, is also the fastest
		//but then its no more an anonymous lambda.
		//This defeats the game purpose.
		public override void TestMethod()
		{
			var root = BuildComposite();
	
			Action<IObject> a = null;
			a = thing =>
				{
					foreach (var item in thing.Children)
					{
						//Console.WriteLine(item.Name);
						a(item);
					}
				};
				
			Performance.Measure(1000000, () =>
			{
				a(root);
			}, "Time " + this.GetType().Name);
		}
			
	}
	
	private class test6 : test
	{
	
		//[TestMethod]
		//Reference test, direct method call
		//There should be no way to get faster than this.
		public override void TestMethod()
		{
			var root = BuildComposite();
	
			Performance.Measure(1000000, () =>
			{
				a(root);
			}, "Time " + this.GetType().Name);
		}
		
		public static void a(IObject thing)
		{
			foreach (var item in thing.Children)
			{
				//Console.WriteLine(item.Name);
				a(item);
			}
		}
			
	}
	
	private class test7 : test
	{
	
		//[TestMethod]
		//Lets try some memoization.
		public override void TestMethod()
		{
			var root = BuildComposite();
	
			Performance.Measure(1000000, () =>
			{
				Y<IObject, int>.Combinator(f => thing =>
				{
					foreach (var item in thing.Children)
					{
						//Console.WriteLine(item.Name);
						f(item);
					}
					return 0;
				})(root);
			}, "Time " + this.GetType().Name);
		}
	
		private class Y<TArg1, TReturn>
		{
			public static Func<TArg1, TReturn> Combinator(Func<Func<TArg1, TReturn>, Func<TArg1, TReturn>> f)
			{
				return f(n => 
					{
						if (memoized == null) memoized = Combinator(f);
						return memoized(n);
					});
			}
			private static Func<TArg1, TReturn> memoized;
		}
	
	}
	
	private interface IObject
	{
		List<IObject> Children { get; }
	}
	
	private class CObject : IObject
	{
		private int lvl;
		public CObject(int lvl)
		{
			this.lvl = lvl;
		}
		public List<IObject> Children 
		{ 
			get
			{
				var l = new List<IObject>() { BuildComposite(lvl + 1) }; 
				if (lvl > 2) l.Clear();
				return l;
			}
		}
	}
	
	private static IObject BuildComposite()
	{
		return new CObject(0);
	}
	
	private static IObject BuildComposite(int lvl)
	{
		return new CObject(lvl);
	}
	
	private class Performance
	{
		public static void Measure(int count, Action a, string msg)
		{
			using(new WallClock(msg))
				Enumerable.Range(1, count).ToList().ForEach(_ => a());
		}
	}
	
	private class WallClock : IDisposable
	{   
		private string name;
		private Stopwatch w;
		public WallClock(string name)
		{
			this.name = name;
			w = Stopwatch.StartNew();
		}
		public void Dispose()
		{
			w.Stop();
			Console.WriteLine(name + " : " + w.ElapsedMilliseconds);
		}
	}
	
	//references
	//http://mikehadlow.blogspot.com.br/2009/03/recursive-linq-with-y-combinator.html
	//http://stackoverflow.com/questions/4763690/alternative-y-combinator-definition
	//http://stackoverflow.com/questions/10550817/c-sharp-anonymous-recursion-and-y-combinator-performance
	//http://blogs.msdn.com/b/wesdyer/archive/2007/02/02/anonymous-recursion-in-c.aspx
	//http://www.justinshield.com/2011/06/recursive-lambda-expressions-in-c-using-ycombinator/
