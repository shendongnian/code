            TextReader reader = File.OpenText("myfile.cs");
    	    SyntaxTree syntaxTree;
    
    		CSharpParser parser = new CSharpParser();
    		syntaxTree = parser.Parse(reader, "myfile.cs");
    
            IEnumerable<AstNode> desc = syntaxTree.Descendants;
    
            foreach(AstNode astNode in desc)
    		{
                System.Console.WriteLine(astNode.GetType());
    		}
