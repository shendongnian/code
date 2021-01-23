    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Mono.CSharp;
    
    namespace MonoREPLTester
        {
        public class Program
            {
            static string mystring;
            static void Main(string[] args)
                {
                var evaluator = new Evaluator(new CompilerContext(new CompilerSettings(), new ConsoleReportPrinter()));                             
                Evaluator.ReferenceAssembly(Assembly.GetExecutingAssembly());
                Evaluator.Run("using MonoREPLTester;")
                mystring = "hello";
                object result = evaluator.Run("mystring.IndexOf('e');");
                Console.WriteLine("Result: " + result);
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                }
            }
        }
