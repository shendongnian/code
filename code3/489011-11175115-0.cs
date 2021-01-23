    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Roslyn.Compilers;
    using Roslyn.Compilers.CSharp;
    using Roslyn.Services;
    using Roslyn.Services.CSharp;
    
    class Program
    {
        static void Main(string[] args)
        {
            // Create the solution with an empty document
            ProjectId projectId;
            DocumentId documentId;
            var solution = Solution.Create(SolutionId.CreateNewId())
                .AddProject("MyProject", "MyProject", LanguageNames.CSharp, out projectId)
                .AddDocument(projectId, @"C:\file.cs", string.Empty, out documentId);
    
            var document = solution.GetDocument(documentId);
            var root = (CompilationUnitSyntax)document.GetSyntaxRoot();
    
            // Add the namespace
            var namespaceAnnotation = new SyntaxAnnotation();
            root = root.WithMembers(
                Syntax.NamespaceDeclaration(
                    Syntax.ParseName("MyNamespace"))
                        .NormalizeWhitespace()
                        .WithAdditionalAnnotations(namespaceAnnotation));
            document = document.UpdateSyntaxRoot(root);
    
            Console.WriteLine("-------------------");
            Console.WriteLine("With Namespace");
            Console.WriteLine(document.GetText().GetText());
    
            // Find our namespace, add a class to it, and update the document
            var namespaceNode = (NamespaceDeclarationSyntax)root
                .GetAnnotatedNodesAndTokens(namespaceAnnotation)
                .Single()
                .AsNode();
    
            var classAnnotation = new SyntaxAnnotation();
            var newNamespaceNode = namespaceNode
                .WithMembers(
                    Syntax.List<MemberDeclarationSyntax>(
                        Syntax.ClassDeclaration("MyClass")
                            .WithAdditionalAnnotations(classAnnotation)));
            root = root.ReplaceNode(namespaceNode, newNamespaceNode).NormalizeWhitespace();
            document = document.UpdateSyntaxRoot(root);
    
            Console.WriteLine("-------------------");
            Console.WriteLine("With Class");
            Console.WriteLine(document.GetText().GetText());
    
            // Find the class, add a method to it and update the document
            var classNode = (ClassDeclarationSyntax)root
                .GetAnnotatedNodesAndTokens(classAnnotation)
                .Single()
                .AsNode();
            var newClassNode = classNode
                .WithMembers(
                    Syntax.List<MemberDeclarationSyntax>(
                        Syntax.MethodDeclaration(
                            Syntax.ParseTypeName("void"),
                            "MyMethod")
                            .WithBody(
                                Syntax.Block())));
            root = root.ReplaceNode(classNode, newClassNode).NormalizeWhitespace();
            document = document.UpdateSyntaxRoot(root);
    
            Console.WriteLine("-------------------");
            Console.WriteLine("With Method");
            Console.WriteLine(document.GetText().GetText());
        }
    }
