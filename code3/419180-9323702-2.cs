	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Runtime.InteropServices;
	namespace ConsoleApplication2
	{
		class Program
		{
			[DllImport("C:\\Users\\Kep\\Documents\\Visual Studio 2010\\Projects\\SODLL\\Debug\\DLL.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "fnSumofTwoDigits")]
			public static extern int fnSumofTwoDigits(int a, int b);
			static void Main(string[] args)
			{
				int A = fnSumofTwoDigits(3, 4);
				Console.WriteLine("A = " + A);
				Console.ReadLine();
			}
		}
	}
