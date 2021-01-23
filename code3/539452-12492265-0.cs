    if (type == typeof(Dictionary<string, string>))
    {
        string variableName = "dict";
    
        CodeVariableDeclarationStatement codeVariableDeclarationStatement = new CodeVariableDeclarationStatement(new CodeTypeReference(type.FullName), variableName,
                new CodeObjectCreateExpression(type)
        );
    
        property.GetStatements.Add(codeVariableDeclarationStatement);
        property.GetStatements.Add(AddPropertyValues(new CodeSnippetExpression(string.Format(@"""{0}"", ""{1}""", "a", "xx xx1")), variableName));
        property.GetStatements.Add(AddPropertyValues(new CodeSnippetExpression(string.Format(@"""{0}"", ""{1}""", "b", "xx xx2")), variableName));
        property.GetStatements.Add(AddPropertyValues(new CodeSnippetExpression(string.Format(@"""{0}"", ""{1}""", "c", "xx xx3")), variableName));
    
        property.GetStatements.Add(new CodeMethodReturnStatement(new CodeSnippetExpression(variableName)));
    }
    static CodeStatement AddPropertyValues(CodeExpression exp, string variableReference)
    {
        return new CodeExpressionStatement(
            new CodeMethodInvokeExpression(
                new CodeMethodReferenceExpression(
                    new CodeTypeReferenceExpression(new CodeTypeReference(variableReference)),
                        "Add"),
                            new CodeExpression[]{
                                exp,
                                    }));
    }
