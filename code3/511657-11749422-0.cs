    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Roslyn.Compilers.CSharp;
    
    namespace RoslynTest
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                var code = @"
                
                using System;
    
                class Program() {
                    public void My() {
                        do {
                            Console.WriteLine(""hello world"");
                        }
                        until (i > 10)
                    }
                }
                ";
    
                var syntaxTree = SyntaxTree.ParseCompilationUnit(code);
    
                var syntaxRoot = syntaxTree.GetRoot();
    
                var replaceDictionary = new Dictionary<DoStatementSyntax, DoStatementSyntax>();
    
                foreach (var node in syntaxRoot.DescendantNodes())
                {
                    if (node is DoStatementSyntax)
                    {
                        var doStatement = node as DoStatementSyntax;
                        var untilNode = doStatement.Condition.ChildNodes().FirstOrDefault((_node =>
                        {
                            var identifierSyntaxNode = _node as IdentifierNameSyntax;
                            if (identifierSyntaxNode != null)
                            {
                                return identifierSyntaxNode.Identifier.ValueText == "until";
                            }
                            return false;
                        })) as IdentifierNameSyntax;
    
                        var conditionNode = doStatement.Condition.ChildNodes().OfType<ArgumentListSyntax>().FirstOrDefault();
    
                        if (untilNode != null && conditionNode != null)
                        {
    
                            var whileNode = Syntax.ParseToken("while");
    
                            var condition = Syntax.ParseExpression("(!" + conditionNode.GetFullText() + ")");
    
                            var newDoStatement = doStatement.WithWhileKeyword(whileNode).WithCondition(condition);
    
                            replaceDictionary.Add(doStatement, newDoStatement);
    
                        }
    
                    }
                }
    
                syntaxRoot = syntaxRoot.ReplaceNodes(replaceDictionary.Keys, (node1, node2) => replaceDictionary[node1]);
    
                Console.WriteLine(syntaxRoot.GetFullText());
    
            }
        }
    }
