            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            CodeGeneratorOptions options = new CodeGeneratorOptions();
            options.IndentString = "   ";
            options.BracingStyle = "C";
            Type myType = typeof(System.Collections.Generic.Dictionary<string, string>);
            string dictionaryTypeName = myType.FullName;
            CodeTypeReference dictionaryType = new CodeTypeReference(dictionaryTypeName);
            
            // here you create the CodeobjectCreateExpression in order to obtain the string with the name of the type
            StringWriter sw = new StringWriter();
            CodeObjectCreateExpression createExpr = new CodeObjectCreateExpression(dictionaryType);
            codeProvider.GenerateCodeFromExpression(createExpr, sw, options);
            string creationCode = sw.ToString();
            // throw away the final ()
            creationCode = creationCode.Substring(0, creationCode.Length - 2);
            // add initialization
            creationCode = creationCode + @"{{""firstkey"", ""first value""}, {""secondkey"", ""second value""}, {""thirdkey"", ""third value""}}";
            CodeMethodReturnStatement retVal = new CodeMethodReturnStatement(new CodeSnippetExpression(creationCode));
            property.GetStatements.Add(retVal);
