        string code2 = 
        "    public sealed class CustomClass" +
        "    {" +
        "    }"
        ;
        // Compiler and CompilerParameters
        CSharpCodeProvider codeProvider = new CSharpCodeProvider();
        CompilerParameters compParameters = new CompilerParameters();
        CodeDomProvider compiler = CSharpCodeProvider.CreateProvider("CSharp");
        **compParameters.ReferencedAssemblies.Add("System.dll");**
        // Compile the code
        CompilerResults res = codeProvider.CompileAssemblyFromSource(compParameters, code2);
        // Create a new instance of the class 'CustomClass'
            object myClass = res.CompiledAssembly.CreateInstance("CustomClass");
