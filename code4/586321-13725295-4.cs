    sring source = textbox.Text;
    CompilerParameters parameters = new CompilerParameters() {
       GenerateExecutable = false, 
       GenerateInMemory = true 
    };
    var provider = new CSharpCodeProvider();       
    CompilerResults results = provider.CompileAssemblyFromSource(parameters, source);
