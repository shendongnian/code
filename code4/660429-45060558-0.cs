        using System;
        using System.Linq;
        using Microsoft.CodeAnalysis.CSharp;
        using Microsoft.CodeAnalysis.CSharp.Syntax;
        class Program
        {
            static void Main(string[] args)
            {
                var tree = CSharpSyntaxTree.ParseText(@"
        /// <summary> This is an xml doc comment </summary>
        class C
        {
        }");
                var root = (CompilationUnitSyntax) tree.GetRoot();
                var classNode = (ClassDeclarationSyntax) (root.Members.First());
                var trivias = classNode.GetLeadingTrivia();
                var xmlCommentTrivia = trivias.FirstOrDefault(t => t.Kind() == SyntaxKind.SingleLineDocumentationCommentTrivia);
                var xml = xmlCommentTrivia.GetStructure();
                Console.WriteLine(xml);
                var compilation = CSharpCompilation.Create("test", syntaxTrees: new[] {tree});
                var classSymbol = compilation.GlobalNamespace.GetTypeMembers("C").Single();
                var docComment = classSymbol.GetDocumentationCommentXml();
                Console.WriteLine(docComment);
            }
        }
