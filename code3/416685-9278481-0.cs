	using System;
	using System.Diagnostics;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.IO;
	using System.ComponentModel;
	using System.Runtime.InteropServices;
	using Microsoft.Win32.SafeHandles;
	namespace ConsoleApplication1
	{
		class Program {
			static void Main(string[] args)
			{
				string caminho = fixPathForLong(@args[0]);
				Process.Start(caminho);
			}
			private static string fixPathForLong(String path) {
				if (!path.StartsWith(@"\\?\"))
					path = @"\\?\" + path;
				return path;
			}
		}
	}
