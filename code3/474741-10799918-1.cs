    using System.CodeDom.Compiler;
    using Microsoft.CSharp;
    // ...
    string source = @"public static class C
                      {
                          public static void M(int i)
                          {
                              System.Console.WriteLine(""The answer is "" + i);
                          }
                      }";
    Action<int> action;
    using (var provider = new CSharpCodeProvider())
    {
        var options = new CompilerParameters { GenerateInMemory = true };
        var results = provider.CompileAssemblyFromSource(options, source);
        var method = results.CompiledAssembly.GetType("C").GetMethod("M");
        action = (Action<int>)Delegate.CreateDelegate(typeof(Action<int>), method);
    }
    action(42);    // displays "The answer is 42"
