        static Assembly Compile(string script)
        {
            CompilerParameters options = new CompilerParameters();
            options.GenerateExecutable = false;
            options.GenerateInMemory = true;
            options.ReferencedAssemblies.Add("System.dll");
            options.ReferencedAssemblies.Add("ScriptProxy.dll");
            Microsoft.CSharp.CSharpCodeProvider provider = new Microsoft.CSharp.CSharpCodeProvider();
            CompilerResults result = provider.CompileAssemblyFromSource(options, script);
            // Check the compiler results for errors
            StringWriter sw = new StringWriter();
            foreach (CompilerError ce in result.Errors)
            {
                if (ce.IsWarning) continue;
                sw.WriteLine("{0}({1},{2}: error {3}: {4}", ce.FileName, ce.Line, ce.Column, ce.ErrorNumber, ce.ErrorText);
            }
            // If there were errors, raise an exception...
            string errorText = sw.ToString();
            if (errorText.Length > 0)
                throw new ApplicationException(errorText);
            return result.CompiledAssembly;
        }
