    treeBuilder.In(
        visitor.Visit(arguments[0]).AsExpression(),
        treeBuilder.MethodCall("SELECT [Id] FROM [dbo].[GetCategories]", new[] {
            visitor.Visit(arguments[1]).AsExpression()
        }).AsExpression()
    )
