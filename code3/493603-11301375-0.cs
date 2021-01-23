    CSharpCodeProvider codeProvider = new CSharpCodeProvider();
    ICodeCompiler icc = codeProvider.CreateCompiler();
    System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
    parameters.GenerateExecutable = true;
    parameters.OutputAssembly = Output;
    CompilerResults results = icc.CompileAssemblyFromSource(parameters,SourceString);
