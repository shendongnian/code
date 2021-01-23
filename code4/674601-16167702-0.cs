    CSharpParser parser = new CSharpParser();
    SyntaxTree syntaxTree = parser.Parse(@"namespace Test
        {
    
            public class TestClass
            {
                public void Method(string bob)
                {
                }
            }
        }");
    var result = syntaxTree.Descendants.OfType<MethodDeclaration>().Where(x => x.Descendants.OfType<ParameterDeclaration>().Any(y => y.NameToken.Name == "bob"));
    if (result.Any())
    {
        Console.WriteLine("We Win");
    }
