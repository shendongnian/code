    using System;
    using System.Linq;
    using Roslyn.Compilers;
    using Roslyn.Compilers.CSharp;
    class Program
    {
        static void Main(string[] args)
        {
            var oldRootNode = Syntax.ParseCompilationUnit(
                "class C { void M() { \"\".GetType(); } }");
            var oldStatementNode = oldRootNode.DescendantNodes().OfType<ExpressionStatementSyntax>().First();
            var oldExpressionNode = oldStatementNode.Expression;
            var newExpressionNode = Syntax.ParenthesizedExpression(oldExpressionNode);
            var newStatementNode = oldStatementNode.WithExpression(newExpressionNode);
            var newRootNode = oldRootNode.ReplaceNode(oldStatementNode, newStatementNode);
            Console.WriteLine(oldRootNode.ToString());
            Console.WriteLine(newRootNode.ToString());
        }
    }
