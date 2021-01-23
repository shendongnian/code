    sring source = textbox.Text;
    CSharpCodeProvider codeProvider = new CSharpCodeProvider();
    ICodeCompiler icc = codeProvider.CreateCompiler();
    CompilerParameters parameters = new CompilerParameters();
    parameters.GenerateExecutable = false;
    parameters.GenerateInMemory = true;
       
    CompilerResults results = icc.CompileAssemblyFromSource(parameters, source);
