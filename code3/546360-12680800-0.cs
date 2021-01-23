     public static CompilerResults CompileScript(string source)
            {
                CompilerParameters parms = new CompilerParameters();
                parms.GenerateExecutable = false;
                parms.GenerateInMemory = true;
                parms.IncludeDebugInformation = false;
                parms.ReferencedAssemblies.Add("System.dll");
                // Add whatever references you might need here 
                CodeDomProvider compiler = CSharpCodeProvider.CreateProvider("CSharp");
                return compiler.CompileAssemblyFromSource(parms, source);
            }
