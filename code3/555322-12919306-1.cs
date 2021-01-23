            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateExecutable = false;
            parameters.GenerateInMemory = false;
            parameters.WarningLevel = 3;
            parameters.CompilerOptions = "/optimize";
            parameters.OutputAssembly = "C:\\test\\test.dll";
            parameters.ReferencedAssemblies.Add("Microsoft.CSharp.dll");
            parameters.ReferencedAssemblies.Add("System.dll");
            parameters.ReferencedAssemblies.Add("System.Core.dll");
            parameters.ReferencedAssemblies.Add("System.Data.dll");
            parameters.ReferencedAssemblies.Add("System.Data.DataSetExtensions.dll");
            parameters.ReferencedAssemblies.Add("System.XML.dll");
            parameters.ReferencedAssemblies.Add("System.XML.Linq.dll");
           
            CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, _BaseCode.ToArray());
            if (results.Errors.Count > 0)
            {
                LogError(results.Errors[0].ErrorText, "Error Compiling", null, "", ErrorLevel.Critical);
                throw new Exception("Error Compiling..");
            }
