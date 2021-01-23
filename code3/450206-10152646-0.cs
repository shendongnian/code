	using System.Runtime.CompilerServices;
	
	class test
	{
		private object Lock { get; set; }
	
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void Foo()
		{
			// Now this instance is locked
		}
	}
