    using (Microsoft.CSharp.CSharpCodeProvider foo = 
           new Microsoft.CSharp.CSharpCodeProvider())
    {
        var res = foo.CompileAssemblyFromSource(
            new System.CodeDom.Compiler.CompilerParameters() 
            {  
                GenerateInMemory = true 
            }, 
            "public class FooClass { public int Execute() { return 1;}}"
        );
        var real = new FooClass();
        Test(() => real.Execute());                   // benchmark, direct call
               
        var type = res.CompiledAssembly.GetType("FooClass");
        var obj = Activator.CreateInstance(type);    
        var method = type.GetMethod("Execute");
        var input = new object[] { };                
        Test(() => (int)method.Invoke(obj, input));   // reflection invoke  
        dynamic dyn = Activator.CreateInstance(type);  
        Test(() => dyn.Execute());                    // dynamic object invoke
        var action = (Func<int>)Delegate.CreateDelegate(typeof(Func<int>), null, method); 
        Test(() => action());                         // delegate
    }
