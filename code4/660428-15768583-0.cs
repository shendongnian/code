    using Roslyn.Compilers.CSharp;
    using System;
    using System.Linq;
    
    class Program
    {
        static void Main(string[] args)
        {
            var tree = SyntaxTree.ParseText(@"
    /// <summary>This is an xml doc comment</summary>
    class C
    {
    }");
            var classNode = (ClassDeclarationSyntax)tree.GetRoot().Members.First();
            var trivia = classNode.GetLeadingTrivia().Single(t => t.Kind == SyntaxKind.DocumentationCommentTrivia);
            var xml = trivia.GetStructure();
            Console.WriteLine(xml);
    
            var compilation = Compilation.Create("test", syntaxTrees: new[] { tree });
            var classSymbol = compilation.GlobalNamespace.GetTypeMembers("C").Single();
            var docComment = classSymbol.GetDocumentationComment();
            Console.WriteLine(docComment.SummaryTextOpt);
        }
    }
