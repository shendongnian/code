    using (Microsoft.CSharp.CSharpCodeProvider foo = new Microsoft.CSharp.CSharpCodeProvider())
    {
        var params = new System.CodeDom.Compiler.CompilerParameters();
        params.GenerateInMemory = true;
        // Add the reference to the current assembly which defines IFoo
        params.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
        // Implement the IFoo interface in the dynamic code
        var res = foo.CompileAssemblyFromSource(params, "public class FooClass : IFoo { public string Execute() { return \"output!\";}}");
        var type = res.CompiledAssembly.GetType("FooClass");
        // Cast the created object to IFoo
        IFoo obj = (IFoo)Activator.CreateInstance(type);
        // Use the object through the IFoo interface
        obj.Execute();
    }
