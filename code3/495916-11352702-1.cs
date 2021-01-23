    var cu = SyntaxFactory.CompilationUnit()
                .AddMembers(
                    SyntaxFactory.NamespaceDeclaration(Syntax.IdentifierName("ACO"))
                            .AddMembers(
                            SyntaxFactory.ClassDeclaration("MainForm")
                                .AddBaseListTypes(SyntaxFactory.ParseTypeName("System.Windows.Forms.Form"))
                                .WithModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                                .AddMembers(
                                    Syntax.PropertyDeclaration(SyntaxFactory.ParseTypeName("System.Windows.Forms.Timer"), "Ticker")
                                            .AddAccessorListAccessors(
                                            SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
                                            SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))),
                                    SyntaxFactory.MethodDeclaration(SyntaxFactory.ParseTypeName("void"), "Main")
                                            .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                                            .AddAttributes(SyntaxFactory.AttributeDeclaration().AddAttributes(SyntaxFactory.Attribute(SyntaxFactory.IdentifierName("STAThread"))))
                                            .WithBody(SyntaxFactory.Block())
                                    )
                            )
                    );
