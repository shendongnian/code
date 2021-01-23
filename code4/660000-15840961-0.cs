	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.Diagnostics;
	using System.Reflection;
	using Python.Runtime;
	namespace npythontest
	{
		public class Program
		{
			static void Main(string[] args)
			{
				string external_file = "c:\\\\temp\\\\a.py";
				Console.WriteLine("Hello World!");
				PythonEngine.Initialize();
				IntPtr pythonLock = PythonEngine.AcquireLock();
				var mod = Python.Runtime.PythonEngine.ImportModule("os.path");
				var ret = mod.InvokeMethod("join", new Python.Runtime.PyString("my"), new Python.Runtime.PyString("path"));
				Console.WriteLine(mod);
				Console.WriteLine(ret);
				PythonEngine.RunSimpleString("import os.path\n");
				PythonEngine.RunSimpleString("p = os.path.join(\"other\",\"path\")\n");
				PythonEngine.RunSimpleString("print p\n");
				PythonEngine.RunSimpleString("print 3+2");
				PythonEngine.RunSimpleString("execfile('" + external_file + "')");
				PythonEngine.ReleaseLock(pythonLock);
				PythonEngine.Shutdown();
			}
		}
	}
