        private Assembly Compile(string fileName)
        {
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CompilerParameters cp = new CompilerParameters();
            cp.GenerateExecutable = false;
            cp.GenerateInMemory = true;
            cp.TreatWarningsAsErrors = false;
            CompilerResults cr = provider.CompileAssemblyFromFile(cp, fileName);
            return cr.CompiledAssembly;
        }
