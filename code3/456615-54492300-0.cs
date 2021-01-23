                    string content = File.ReadAllText(@Path.GetDirectoryName(Application.ExecutablePath) + "\\r.cs");
                    char[] seperators = { '\n', '\r', '\t' };
                    string[] code = content.Split(seperators);
                    CompilerParameters CompilerParams = new CompilerParameters();
                    string outputDirectory = Directory.GetCurrentDirectory();
                    CompilerParams.GenerateInMemory = true;
                    CompilerParams.TreatWarningsAsErrors = false;
                    CompilerParams.GenerateExecutable = false;
                    CompilerParams.CompilerOptions = "/optimize";
                    CompilerParams.GenerateExecutable = false;
                    CompilerParams.OutputAssembly = "r.dll";
                    FileStream fileStream = File.Open(Path.GetDirectoryName(Application.ExecutablePath) + "\\Output\\r.dll",FileMode.Open);
                    string references =  fileStream.Name;
                    
                    
                  
                    CompilerParams.ReferencedAssemblies.Add(references);
                    fileStream.Close();
                    CSharpCodeProvider provider = new CSharpCodeProvider();
                    CompilerResults compile = provider.CompileAssemblyFromFile(CompilerParams, Path.GetDirectoryName(Application.ExecutablePath) + "\\r.cs");
                    
                    if (compile.Errors.HasErrors)
                    {
                        string text = "Compile error: ";
                        foreach (CompilerError ce in compile.Errors)
                        {
                            text += "rn" + ce.ToString();
                        }
                        throw new Exception(text);
                    }
                    Module module = compile.CompiledAssembly.GetModules()[0];
                    Type mt = null;
                    MethodInfo methInfo = null;
                    MemberInfo[] memberInfo;
                    //var dll = Assembly.LoadFile(references);
                    
                    if (module != null)
                    {
                        mt = module.GetType("materialclassifier.ClassifierFiles");
                    }
                    
                    if (mt != null)
                    {
                        memberInfo = mt.GetMembers();
                        methInfo = mt.GetMethod("main");
                    }
                    if (methInfo != null)
                    {
                        Console.WriteLine(methInfo.Invoke(null, new object[] { "here in dyna code" }));
                        
                    }
