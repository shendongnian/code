	using System.Diagnostics;
	using System.Runtime.InteropServices;
	namespace ConsoleApplication1
	{
		public struct mySize
		{
			public int x, y;
		}
		static class Program
		{
			[DllImport("ClassLibrary.dll")]
			static extern int getX(ref mySize size);
			static void Main(string[] args)
			{
				var size = new mySize { x=100, y=200 };
				int x = getX(ref size);
				Debug.Assert(x == 100);
			}
		}
	}
