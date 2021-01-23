	using System.Runtime.CompilerServices;
	
	class Test
	{
		private object Lock { get; set; }
	
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void Foo()
		{
			// Now this instance is locked
		}
	}
