    <#@ template    hostspecific= "true"                            #>
    <#@ assembly    name        = "System.Core"                     #>
    <#@ assembly    name        = "Roslyn.Compilers"                #>
    <#@ assembly    name        = "Roslyn.Compilers.CSharp"         #>
    <#@ import      namespace   = "System.IO"                       #>
    <#@ import      namespace   = "System.Linq"                     #>
    <#@ import      namespace   = "Roslyn.Compilers.CSharp"         #>
            
    <#
        var host    = Path.GetFullPath(Host.ResolvePath(@".\Class2.cs"));
        var content = File.ReadAllText(host);
        var tree = SyntaxTree.ParseCompilationUnit(content);
        var methods = tree
            .GetRoot()
            .ChildNodes()
            .OfType<NamespaceDeclarationSyntax>()
            .SelectMany(x => x.ChildNodes())
            .OfType<ClassDeclarationSyntax>()
            .SelectMany(x => x.ChildNodes())
            .OfType<MethodDeclarationSyntax>()
            .ToArray()
            ;
    #>            
                                               
    namespace StackOverflow
    {
        using System;
        static partial class Program
        {
            public static void Main()
            {
    <#
        foreach (var method in methods)
        {
            var parent = (ClassDeclarationSyntax)method.Parent;
            var types = method
                .ParameterList
                .ChildNodes()
                .OfType<ParameterSyntax>()
                .Select(t => t.Type.PlainName)
                .ToArray()
                ;
            var plist = string.Join(", ", types);
    #>
                Console.WriteLine("<#=parent.Identifier.ValueText#>.<#=method.Identifier.ValueText#>(<#=plist#>).ToString()");
    <#
        }
    #>
            }
        }
    }
