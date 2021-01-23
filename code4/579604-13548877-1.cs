    using Microsoft.CSharp;
    using System;
    using System.CodeDom.Compiler;
    using System.Linq;
    using System.Reflection;
    namespace EquationSolver
    {
        public class EquationSolver
        {
            MethodInfo meth;
            double ExpectedResult;
            public EquationSolver(string equation)
            {
            var codeProvider = new CSharpCodeProvider();            
            var splitted = equation.Split(new[] {'='});
            ExpectedResult = double.Parse(splitted[0]);
            var SourceString = "using System; namespace EquationSolver { public static class Eq { public static double Solve(double T) { return "+
                splitted[1] + ";}}}";
            System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateInMemory = true;
            
            
            CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, SourceString);
            var cls = results.CompiledAssembly.GetType("EquationSolver.Eq");
            meth = cls.GetMethod("Solve", BindingFlags.Static | BindingFlags.Public);
                        
        }
        public double Evaluate(double T)
        {            
            return (double)meth.Invoke(null, new[] { (object)T });
        }
        public double SearchT(double start, double end, double tolerance)
        {            
            do
            {
                var results = Enumerable.Range(0, 4).Select(x => start + (end - start) / 3 * x).Select(x => new Tuple<double, double>(
                    x, Evaluate(x))).ToArray();
                foreach (var result in results)
                {
                    if (Math.Abs(result.Item2 - ExpectedResult) <= tolerance)
                    {
                        return result.Item1;
                    }
                }
                if (Math.Abs(results[2].Item2 - ExpectedResult) > Math.Abs(results[1].Item2 - ExpectedResult))
                {
                    end -= (end - start) / 3;                    
                }
                else
                {
                    start += (end - start) / 3;
                }
            } while (true);
        }
      }
   
    }
