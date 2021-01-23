	namespace ExceptionTest
	{
		class Program
		{
			static void ThrowException()
			{
				throw new System.Exception();  // The line that I WANT the debugger to show.
			}
			
			[DebuggerNonUserCode()]
			static void Main(string[] args)
			{
				try
				{
					ThrowException();
				}
				catch (System.Exception)
				{
					System.Console.WriteLine("An exception was thrown.");
					throw;  // The line that the debugger ACTUALLY shows.
				}
			}
		}
	}
