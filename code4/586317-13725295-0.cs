    sring source = textbox.Text;
    CSharpCodeProvider codeProvider = new CSharpCodeProvider();
    ICodeCompiler icc = codeProvider.CreateCompiler();
    CompilerParameters parameters = new CompilerParameters();
    parameters.GenerateExecutable = false;
    parameters.GenerateInMemory = true;
       
    CompilerResults results = icc.CompileAssemblyFromSource(parameters, source);
    if (results.Errors.HasErrors)
    {
        foreach(var error in results.Errors)
            MessageBox.Show(error.ToString());
        return;
    }
    
    var assembly = results.CompiledAssembly;
    var types = assembly.GetTypes();
    
