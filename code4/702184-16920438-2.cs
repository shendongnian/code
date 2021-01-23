        public T GetInstanceOf<T>(string code, string typename)
        {
            Console.WriteLine("Now doing some injection...");
            Console.WriteLine("Creating injected code in memory");
            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            ICodeCompiler icc = codeProvider.CreateCompiler();
            CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateExecutable = false;
            parameters.GenerateInMemory = true;
            //parameters.OutputAssembly = "DynamicCode.dll"; // if specified creates the DLL
            CompilerResults results = icc.CompileAssemblyFromSource(parameters, code);
            //type name = "CodeInjection.DynConcatenateString"
            T codeclass = (T)results.CompiledAssembly.CreateInstance(typename);
            return codeclass;
        }
