    string codeSnippet = @"using System;
    using System.CodeDom;
    using System.CodeDom.Compiler;
    using Microsoft.CSharp;
    using System.Text;
    using System.Reflection;
    
    namespace MyNM
    {
        class MyClass{}
    }";
                //APPROACH:
                //Get using statements in the code snippet from the syntax tree
                //find qualified name(eg:System.Text..) in the using directive 
    
                SyntaxTree tree = SyntaxTree.ParseCompilationUnit(codeSnippet);
                SyntaxNode root = tree.GetRoot();
                IEnumerable<UsingDirectiveSyntax> usingDirectives = root.DescendantNodes().OfType<UsingDirectiveSyntax>();
                foreach(UsingDirectiveSyntax usingDirective in usingDirectives){
                    NameSyntax ns = usingDirective.Name;
                    Console.WriteLine(ns.GetText());
                }
