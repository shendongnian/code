    // Generate a code file for the contracts 
            CodeGeneratorOptions options = new CodeGeneratorOptions();
            options.BracingStyle = "C";
            CodeDomProvider codeDomProvider = CodeDomProvider.CreateProvider("C#");
            // Compile the code file to an in-memory assembly
            // Don't forget to add all WCF-related assemblies as references
            CompilerParameters compilerParameters = new CompilerParameters(
                new string[] { 
                    "System.dll", "System.ServiceModel.dll", 
                    "System.Runtime.Serialization.dll" });
            compilerParameters.GenerateInMemory = true;
            CompilerResults results = codeDomProvider.CompileAssemblyFromDom(compilerParameters, generator.TargetCompileUnit);
