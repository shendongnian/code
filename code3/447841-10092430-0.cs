    CodeTypeDeclaration studentModelClass = …;
    
    var addStudentMethod =
        new CodeMemberMethod
        {
            Name = "AddStudent",
            Parameters =
            {
                new CodeParameterDeclarationExpression(studentClass.Name, "student")
            }
        };
