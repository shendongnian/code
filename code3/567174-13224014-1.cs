    using System; 
    using System.Reflection; 
    using System.CodeDom.Compiler; 
 
    using Microsoft.CSharp; 
 
    class Program 
    { 
       static void Main() 
       { 
          TestExpression("2+1-(3*2)+8/2"); 
          TestExpression("1*2*3*4*5*6"); 
          TestExpression("Invalid expression"); 
       } 
 
       static void TestExpression(string expression) 
       { 
          try 
          { 
             int result = EvaluateExpression(expression); 
             Console.WriteLine("'" + expression + "' = " + result); 
          } 
          catch (Exception) 
          { 
             Console.WriteLine("Expression is invalid: '" + expression + "'"); 
          } 
        } 
 
        public static int EvaluateExpression(string expression) 
        { 
          string code = string.Format  // Note: Use "{{" to denote a single "{" 
          ( 
             "public static class Func{{ public static int func(){{ return {0};}}}}", expression 
          ); 
 
          CompilerResults compilerResults = CompileScript(code); 
 
          if (compilerResults.Errors.HasErrors) 
          { 
             throw new InvalidOperationException("Expression has a syntax error."); 
          } 
 
          Assembly assembly = compilerResults.CompiledAssembly; 
          MethodInfo method = assembly.GetType("Func").GetMethod("func"); 
 
          return (int)method.Invoke(null, null); 
       } 
 
       public static CompilerResults CompileScript(string source) 
       { 
          CompilerParameters parms = new CompilerParameters(); 
 
          parms.GenerateExecutable = false; 
          parms.GenerateInMemory = true; 
          parms.IncludeDebugInformation = false; 
 
          CodeDomProvider compiler = CSharpCodeProvider.CreateProvider("CSharp"); 
 
          return compiler.CompileAssemblyFromSource(parms, source); 
       } 
    } 
