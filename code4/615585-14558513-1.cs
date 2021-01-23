    static void EnumerateMethodsWithRefParameters()
    {
        foreach (FileInfo file in new DirectoryInfo(RuntimeEnvironment.GetRuntimeDirectory()).GetFiles("*.dll"))
        {
            AssemblyDefinition asm;
            try
            {
                asm = AssemblyFactory.GetAssembly(file.FullName);
            }
            catch (ImageFormatException)
            {
                continue;
            }
            bool assemblyWritten = false;
            foreach (ModuleDefinition module in asm.Modules)
            {
                foreach (TypeDefinition type in module.Types)
                {
                    if (!ChooseType(type))
                        continue;
                    bool typeWritten = false;
                    foreach (MethodDefinition method in type.Methods)
                    {
                        if (!ChooseMethod(method))
                            continue;
                        if (!assemblyWritten)
                        {
                            Console.WriteLine("Assembly " + asm.Name);
                            assemblyWritten = true;
                        }
                        if (!typeWritten)
                        {
                            Console.WriteLine(" Type " + type.Name);
                            typeWritten = true;
                        }
                        Console.WriteLine("  Method " + GetMethodSignature(method));
                    }
                }
            }
        }
    }
    static bool ChooseType(TypeDefinition type)
    {
        if (!type.IsPublic)
            return false;
        if (IsComRelatedOrObsolete(type))
            return false;
        return true;
    }
    static bool ChooseMethod(MethodDefinition method)
    {
        if (!method.IsPublic)
            return false;
        foreach (ParameterDefinition parameter in method.Parameters)
        {
            if ((parameter.ParameterType is ReferenceType) && (!parameter.IsOut))
                return true;
        }
        return false;
    }
    static bool IsComRelatedOrObsolete(TypeDefinition type)
    {
        foreach (CustomAttribute att in type.CustomAttributes)
        {
            if (att.Constructor.DeclaringType.FullName == typeof(ObsoleteAttribute).FullName)
                return true;
            if (att.Constructor.DeclaringType.FullName == typeof(InterfaceTypeAttribute).FullName)
            {
                if ((att.Constructor.Parameters.Count > 0) &&
                    (att.Constructor.Parameters[0].ParameterType.FullName == typeof(ComInterfaceType).FullName))
                    return true;
            }
            if (att.Constructor.DeclaringType.FullName == typeof(ComVisibleAttribute).FullName)
                return true;
            if (att.Constructor.DeclaringType.FullName == typeof(ComConversionLossAttribute).FullName)
                return true;
            if (att.Constructor.DeclaringType.FullName == typeof(ComImportAttribute).FullName)
                return true;
        }
        return false;
    }
    static string GetMethodSignature(MethodDefinition method)
    {
        StringBuilder sb = new StringBuilder(method.ReturnType.ReturnType.FullName);
        sb.Append(' ');
        sb.Append(method.Name);
        sb.Append("(");
        for (int i = 0; i < method.Parameters.Count; i++)
        {
            ParameterDefinition p = method.Parameters[i];
            sb.Append(p.ParameterType.FullName);
            if (!string.IsNullOrEmpty(p.Name))
            {
                sb.Append(' ');
                sb.Append(p.Name);
            }
            if (i != (method.Parameters.Count - 1))
            {
                sb.Append(", ");
            }
        }
        sb.Append(")");
        return sb.ToString();
    }
