    static void Main(string[] args)
    {
        string code = "int[] arrInt = {10, 20, 30, 40, 50};";
        //Parse Syntax tree
        var tree = Roslyn.Compilers.CSharp.SyntaxTree.ParseText(code);
        //Locate the arrInt identifier in the Syntax tree
        var declarator = tree.GetRoot().DescendantNodesAndSelf().Where(t => t.Kind == Roslyn.Compilers.CSharp.SyntaxKind.VariableDeclarator
            && ((Roslyn.Compilers.CSharp.VariableDeclaratorSyntax)t).Identifier.ValueText == "arrInt").First() as Roslyn.Compilers.CSharp.VariableDeclaratorSyntax;
        var index = 1;
        var expression = GetExpressionAtInitializer(declarator, index);
        Console.WriteLine(expression);
        //Examine 'expression' for more information on value at the second index            
    }
    private static Roslyn.Compilers.CSharp.ExpressionSyntax GetExpressionAtInitializer(Roslyn.Compilers.CSharp.VariableDeclaratorSyntax declarator, int index)
    {
        var initializerExpression = declarator.Initializer.Value as Roslyn.Compilers.CSharp.InitializerExpressionSyntax;
        var expression = initializerExpression.Expressions[index];
        return expression;
    }
