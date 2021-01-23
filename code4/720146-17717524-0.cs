    private static void StackOverflowTest()
    {
        var syntaxTree = SyntaxTree.ParseText(@"
        using System.Linq.Expressions;
        namespace ConsoleApplication1
        {
            class Program
            {
                static void Main(string[] args)
                {
                    Expression<del> myET = x => x.Age; //for example in ASP.NET MVC forms
                    Person.Name = ""vitia""
                    Person.Move();
                }
            }
        }");
            
        EmitStatement(syntaxTree, SyntaxKind.ParenthesizedLambdaExpression);
        EmitStatement(syntaxTree, SyntaxKind.SimpleLambdaExpression);
        EmitStatement(syntaxTree, SyntaxKind.MethodDeclaration);
    }
    private static void EmitStatement(SyntaxTree syntaxTree, SyntaxKind sk)
    {
        var expressionNodes = syntaxTree.
            GetRoot().
            DescendantNodes().Where(n => n.Kind == sk);
        foreach (var expressionNode in expressionNodes)
        {
            Console.WriteLine(expressionNode.ToString());
        }
    }
