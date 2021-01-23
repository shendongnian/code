    using System.CodeDom.Compiler;
    using Microsoft.CSharp;
    // ...
    string src = @"public static class C
                   {
                       public static void M(int i)
                       {
                           System.Console.WriteLine(""The answer is "" + i);
                       }
                   }";
    Action<int> action;
    using (var cscp = new CSharpCodeProvider())
    {
        var cp = new CompilerParameters { GenerateInMemory = true };
        var cr = cscp.CompileAssemblyFromSource(cp, src);
        var mi = cr.CompiledAssembly.GetType("C").GetMethod("M");
        action = (Action<int>)Delegate.CreateDelegate(typeof(Action<int>), mi);
    }
    action(42);    // displays "The answer is 42"
