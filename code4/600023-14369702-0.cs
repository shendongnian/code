    public static bool AssemblyIncludesCustomAttribute(string assemblyPath, string customAttributeName)
            {
                if (assemblyPath == null) throw new ArgumentNullException("assemblyPath");
                if (customAttributeName == null) throw new ArgumentNullException("customAttributeName");            
    
                AssemblyDefinition assemblyDef = AssemblyDefinition.ReadAssembly(assemblyPath);
    
                return assemblyDef.CustomAttributes.Any(ca => ca.AttributeType.FullName == customAttributeName);
            }
