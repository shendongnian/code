    private Type CompileRazorView(string virtualPath, FileInfo file, Assembly partialViewAssembly)
            {
                var config = WebConfigurationManager.OpenWebConfiguration("~/Views/web.config");
                var section = config.GetSectionGroup("system.web.webPages.razor") as RazorWebSectionGroup;
                var host = MvcWebRazorHostFactory.CreateHostFromConfig(section, virtualPath);
                var engine = new RazorTemplateEngine(host);
                using (var stream = file.OpenRead())
                {
                    using (var reader = new StreamReader(stream))
                    {
                        var result = engine.GenerateCode(reader);
                        string code = null;
                        using (var tw = new StringWriter())
                        {
                            CodeProvider.GenerateCodeFromCompileUnit(result.GeneratedCode, tw, new CodeGeneratorOptions());
                            tw.Flush();
                            code = tw.ToString();
                        }
                        var compilerParameters = new CompilerParameters()
                        {
                            MainClass = host.DefaultClassName,
                            GenerateInMemory = true,
                            IncludeDebugInformation = true,
                        };
                        var thisAssembly = Application.GetType().Assembly;
                        var thisAssemblyName = thisAssembly.GetName();
                        var referencedAssemblies = new List<AssemblyName>();
                        referencedAssemblies.Add(thisAssemblyName);
                        referencedAssemblies.Add(partialViewAssembly.GetName());
                        referencedAssemblies.AddRange(partialViewAssembly.GetReferencedAssemblies());
                        foreach (var applicationReference in thisAssembly.GetReferencedAssemblies())
                        {
                            var assembly = Assembly.Load(applicationReference.FullName);
                            referencedAssemblies.Add(assembly.GetName());
                            referencedAssemblies.AddRange(assembly.GetReferencedAssemblies());
                        }
                        var binPath = Path.GetDirectoryName(thisAssemblyName.CodeBase);
                        var distinctReferences = referencedAssemblies.Distinct((a, b) =>
                            string.Equals(a.FullName, b.FullName, StringComparison.OrdinalIgnoreCase)).ToList();
                        foreach (var reference in distinctReferences)
                        {
                            var referencedAssembly = Assembly.Load(reference.FullName).CodeBase.Substring("file:///".Length);
                            compilerParameters.ReferencedAssemblies.Add(referencedAssembly);
                        }
                        var compilerResults = CodeProvider.CompileAssemblyFromDom(compilerParameters, result.GeneratedCode);
                        if (compilerResults.Errors.HasErrors)
                        {
                            var errorText = new StringBuilder();
                            foreach (var compilerError in compilerResults.Errors)
                            {
                                errorText.AppendLine(compilerError.ToString());
                            }
                            throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                                "The following errors were detected attempting to compile the partial view {0}: \n{1}",
                                virtualPath, errorText));
                        }
                        var typeName = string.Format(CultureInfo.InvariantCulture, "{0}.{1}",
                            host.DefaultNamespace, host.DefaultClassName);
                        var type = compilerResults.CompiledAssembly.GetType(typeName);
                        return type;
    
                    }
                }
            }
