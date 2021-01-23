    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Mono.CSharp;
    using System.Reflection;
    
    namespace MonoREPLTester
    	{
    	public class Program
    		{
    		public static string mystring = "hello";
    		static void Main(string[] args)
    			{
    			var evaluator = new Evaluator(new CompilerContext(new CompilerSettings(), new ConsoleReportPrinter()));
    			evaluator.ReferenceAssembly(Assembly.GetExecutingAssembly());
    			evaluator.Run("using MonoREPLTester;");
    			object result = evaluator.Evaluate("Program.mystring.IndexOf('l');");
    			Console.WriteLine("Result: " + result);
    			Console.WriteLine("Press any key to exit.");
    			Console.ReadKey();
    			}
    		}
    	}
