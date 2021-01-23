    private Assembly BuildAssembly(string code)
    {
        var provider = new CSharpCodeProvider();
        var compiler = provider.CreateCompiler();
        var compilerparams = new CompilerParameters();
        compilerparams.GenerateExecutable = false;
        compilerparams.GenerateInMemory = true;
        var results = compiler.CompileAssemblyFromSource(compilerparams, code);
        if (results.Errors.HasErrors)
        {
            var errors = new StringBuilder("Compiler Errors :\r\n");
            foreach (CompilerError error in results.Errors )
            {
                errors.AppendFormat("Line {0},{1}\t: {2}\n", 
                       error.Line, error.Column, error.ErrorText);
            }
            throw new Exception(errors.ToString());
        }
        else
        {
            return results.CompiledAssembly;
        }
    }
