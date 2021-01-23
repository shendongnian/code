		class DisposableResource : IDisposable
		{
			public DisposableResource(string id) { Id = id; }
			~DisposableResource() { Console.WriteLine(Id + " wasn't disposed.\n"); }
			public string Id { get; private set; }
			public void Dispose() { GC.SuppressFinalize(this); }
		}
		class Base : IDisposable
		{
			public Base()
			{
				try
				{
					throw new Exception();		// Exception 1.
					_baseCtorInit = new DisposableResource("_baseCtorInit");
	//				throw new Exception();		// Exception 2.
				}
				catch(Exception)
				{
	//				Dispose();					// Uncomment to perform cleanup.
					throw;
				}
			}
			public virtual void Dispose()
			{
				if (_baseFieldInit != null)
				{
					_baseFieldInit.Dispose();
					_baseFieldInit = null;
				}
				if (_baseCtorInit != null)
				{
					_baseCtorInit.Dispose();
					_baseCtorInit = null;
				}
			}
			private DisposableResource _baseFieldInit = new DisposableResource("_baseFieldInit");
			private DisposableResource _baseCtorInit;
		}
		class Derived : Base
		{
			public Derived()
			{
				try
				{
	//				throw new Exception();		// Exception 3.
					_derivedCtorInit = new DisposableResource("_derivedCtorInit");
	//				throw new Exception();
				}
				catch (Exception)
				{
	//				Dispose();					// Uncomment to perform cleanup.
					throw;
				}
			}
			public override void Dispose()
			{
				if (_derivedFieldInit != null)
				{
					_derivedFieldInit.Dispose();
					_derivedFieldInit = null;
				}
				if (_derivedCtorInit != null)
				{
					_derivedCtorInit.Dispose();
					_derivedCtorInit = null;
				}
				base.Dispose();
			}
			private DisposableResource _derivedFieldInit = new DisposableResource("_derivedFieldInit");
			private DisposableResource _derivedCtorInit;
		}
		class Program
		{
			static void Main(string[] args)
			{
				try
				{
					Derived d = new Derived();
				}
				catch (Exception)
				{
					Console.WriteLine("Caught Exception.\n");
				}
				GC.Collect();
				GC.WaitForPendingFinalizers();
				GC.Collect();
				Console.WriteLine("\n\nPress any key to continue...\n");
				Console.ReadKey(false);
			}
		}
