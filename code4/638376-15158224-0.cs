    using System;
    using IronPython.Hosting;
    using Microsoft.Scripting.Hosting;
    // we get access to Action and Func on .Net 2.0
    using Microsoft.Scripting.Utils;
   
    namespace TestCallIronPython
    {
        class Program
        {
            public static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
                ScriptEngine pyEngine = Python.CreateEngine();
                ScriptScope pyScope = pyEngine.CreateScope();
                pyScope.SetVariable("test", "test me");
               
                string code = @"
                 print 'test = ' + test
                 class MyClass:
                 def __init__(self):
                   pass
               
                 def somemethod(self):
                   print 'in some method'
               
                 def isodd(self, n):
                   return 1 == n&nbsp;% 2
               ";
               ScriptSource source = pyEngine.CreateScriptSourceFromString(code);
               CompiledCode compiled = source.Compile();
               compiled.Execute(pyScope);
   
               // Get the Python Class
               object MyClass = pyEngine.Operations.Invoke(pyScope.GetVariable("MyClass"));
               // Invoke a method of the class
               pyEngine.Operations.InvokeMember(MyClass, "somemethod", new object[0]);
   
               // create a callable function to 'somemethod'
               Action SomeMethod2 = pyEngine.Operations.GetMember&lt;Action&gt;(MyClass, "somemethod");
               SomeMethod2();
                   
               // create a callable function to 'isodd'
               Func&lt;int, bool&gt; IsOdd = pyEngine.Operations.GetMember&lt;Func&lt;int, bool&gt;&gt;(MyClass, "isodd");
               Console.WriteLine(IsOdd(1).ToString());
               Console.WriteLine(IsOdd(2).ToString());
               
               Console.Write("Press any key to continue . . . ");
               Console.ReadKey(true);
           }
       }
    }
