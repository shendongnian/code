    var method =
        new CodeMemberMethod
        {
            Name = "MyMethod",
            CustomAttributes =
                new CodeAttributeDeclarationCollection
                {
                    new CodeAttributeDeclaration
                    {
                        Name = "PexMethod",
                        Arguments =
                            {
                                new CodeAttributeArgument
                                {
                                    Name = "MaxBranches",
                                    Value = new CodePrimitiveExpression(1000)
                                }
                            }
                    }
                }
        };
