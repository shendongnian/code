    public static bool IncludesTypeWithSpecificExportMetadata<T>(string assemblyPath, string name, T value)
        {
            AssemblyDefinition assemblyDefinition = AssemblyDefinition.ReadAssembly(assemblyPath);
            bool typeWasFound = false;          
            foreach (TypeDefinition typeDefinition in assemblyDefinition.MainModule.GetTypes())
            {
                foreach (CustomAttribute customAttribute in typeDefinition.CustomAttributes)
                {
                    if (customAttribute.AttributeType.FullName == typeof(ExportMetadataAttribute).FullName)
                    {
                        string actualName = (string)customAttribute.ConstructorArguments[0].Value;
                        T actualValue = (T)((CustomAttributeArgument)customAttribute.ConstructorArguments[1].Value).Value;
                        if (actualName.Equals(name) && actualValue.Equals(value))                        
                        {
                            typeWasFound = true;                       
                        }
                    }
                }
            }
            return typeWasFound;
        }
