     public static void CompileScript(string source)
            {
                CompilerParameters parms = new CompilerParameters();
                parms.GenerateExecutable = true;
                parms.GenerateInMemory = true;
                parms.IncludeDebugInformation = false;
                parms.ReferencedAssemblies.Add("System.dll");
                // Add whatever references you might need here 
                CodeDomProvider compiler = CSharpCodeProvider.CreateProvider("CSharp");
                CompilerResults results = compiler.CompileAssemblyFromSource(parms, source);
                file.move(results.CompiledAssembly.Location,"c:\myassembly.dll");
            }
