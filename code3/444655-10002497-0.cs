    public static bool CompileCSharpCode(String sourceFile, String outFile)
            { 
                // Obtain an ICodeCompiler from a CodeDomProvider class.
                CSharpCodeProvider provider = new CSharpCodeProvider(); 
                ICodeCompiler compiler = provider.CreateCompiler(); // Build the parameters for source compilation. 
                CompilerParameters cp = new CompilerParameters(); // Add an assembly reference. 
                cp.ReferencedAssemblies.Add("System.dll"); // Generate an class library instead of // a executable. 
                cp.GenerateExecutable = false; // Set the assembly file name to generate. 
                cp.OutputAssembly = outFile; // Save the assembly as a physical file. 
                cp.GenerateInMemory = false; // Invoke compilation. 
                CompilerResults cr = compiler.CompileAssemblyFromFile(cp, sourceFile);
                if (cr.Errors.Count > 0)
                { // Display compilation errors. 
                    Console.WriteLine("Errors building {0} into {1}", sourceFile, cr.PathToAssembly);
                    foreach (CompilerError ce in cr.Errors)
                    {
                        Console.WriteLine(" {0}", ce.ToString());
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Source {0} built into {1} successfully.", sourceFile, cr.PathToAssembly);
                } // Return the results of compilation. 
                if (cr.Errors.Count > 0) { return false; } else { return true; }
            }
