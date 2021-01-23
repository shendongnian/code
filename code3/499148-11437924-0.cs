            var parseStatementArgument = "var statement = Syntax.ParseStatement(\\\"Console.WriteLine (\\\\\\\"Hello {0}\\\\\\\", parameter1);\\\");";
            var st = Syntax.InvocationExpression(
                                        Syntax.MemberAccessExpression(SyntaxKind.MemberAccessExpression, Syntax.IdentifierName("Syntax"), Syntax.IdentifierName("ParseStatement")))
                                            .AddArgumentListArguments(
                                                Syntax.Argument(Syntax.LiteralExpression(
                                                    SyntaxKind.StringLiteralExpression,
                                                    Syntax.Literal(
                                                        text: "\"" + parseStatementArgument + "\"",
                                                        value: parseStatementArgument.Replace ("\\\\\\", "\\"))
                                        )));
