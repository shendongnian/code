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
                var syntaxTree = SyntaxTree.ParseText(@"
    class C
    {
        internal void M(string s, int i)
        {
        }
    }");
    
    
            }
        }
    
    
    class Walker : SyntaxWalker
    {
        private InterfaceDeclarationSyntax @interface = Syntax.InterfaceDeclaration("ISettings");
    
        private ClassDeclarationSyntax wrapperClass = Syntax.ClassDeclaration("SettingsWrapper")
            .WithBaseList(Syntax.BaseList(
                Syntax.SeparatedList<TypeSyntax>(Syntax.ParseTypeName("ISettings"))));
    
        private ClassDeclarationSyntax @class = Syntax.ClassDeclaration("SettingsClass")
            .WithBaseList(Syntax.BaseList(
                Syntax.SeparatedList<TypeSyntax>(Syntax.ParseTypeName("ISettings"))));
    
        public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            var parameters = node.ParameterList.Parameters.ToArray();
            var typeParameters = node.TypeParameterList.Parameters.ToArray();
            @interface = @interface.AddMembers(
                Syntax.MethodDeclaration(node.ReturnType, node.Identifier.ToString())
                    .AddParameterListParameters(parameters)
                    .AddTypeParameterListParameters(typeParameters));
    
            // More code to add members to the classes too.
        }
    }
