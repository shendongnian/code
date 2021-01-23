    using System;
    using System.CodeDom.Compiler;
    using System.Reflection;
    using Microsoft.CSharp;
    using System.Collections.Generic;
    
    static public class Sample {
        static public double eval(string exp, Dictionary<string,string> varlist){
            CSharpCodeProvider csCompiler = new CSharpCodeProvider();
            CompilerParameters compilerParameters = new CompilerParameters();
            compilerParameters.GenerateInMemory = true;
            compilerParameters.GenerateExecutable = false;
    //      compilerParameters.ReferencedAssemblies.Add("System.dll");
            string temp =
    @"static public class Eval {
        static public double calc() {
            double exp = $exp;
            return exp;
        }
    }";
            string equation = exp;
            foreach(var key in varlist.Keys){
                equation = equation.Replace(key, varlist[key]);
            }
            temp = temp.Replace("$exp", equation);
            CompilerResults results = csCompiler.CompileAssemblyFromSource(compilerParameters,
                new string[1] { temp });
    
            if (results.Errors.Count == 0){
                Assembly assembly = results.CompiledAssembly;
                MethodInfo calc = assembly.GetType("Eval").GetMethod("calc");
                double answer = (double)calc.Invoke(null, null);
                return answer;
            } else {
                Console.WriteLine("expression errors!");
                foreach(CompilerError err in results.Errors){
                    Console.WriteLine(err.ErrorText);
                }
                return Double.NaN;
            }
        }
    }
    class Program {
        static void Main(){
            double value3 = 3;
            double value2 = 2;
            double value8 = 8;
            double value7 = 7;
            double value6 = 6;
            string calculate = " value3 / value2 * value8 / (36 * 840) * value7/ (2.2046 * value6) * value7";
            var vars = new Dictionary<string,string>();
            vars.Add("value3", value3.ToString("F"));
            vars.Add("value2", value2.ToString("F"));
            vars.Add("value8", value8.ToString("F"));
            vars.Add("value7", value7.ToString("F"));
            vars.Add("value6", value6.ToString("F"));
            double result = Sample.eval(calculate, vars);
            Console.WriteLine("{0:F8}", result);
        }
    }
