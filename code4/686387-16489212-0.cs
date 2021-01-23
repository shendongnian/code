    foreach (var parameter in method.GetParameters())
    {
        Type parameterType = parameter.ParameterType;
    
        this.VerifyTypeIsKnown(parameterType, typeSet, parameter.Name, "Parameter");
    
        globalNamespace.Imports.Add(new CodeNamespaceImport(parameterType.Namespace));
    
        var typeArguments = from param in parameterType.GetGenericArguments()
                            select new CodeTypeReference(param);
        var memberParameterType = new CodeTypeReference(parameterType.Name, typeArguments.ToArray<CodeTypeReference>());
    
        var memberParameter = new CodeParameterDeclarationExpression(memberParameterType, parameter.Name);
    
        memberMethod.Parameters.Add(memberParameter);
    }
