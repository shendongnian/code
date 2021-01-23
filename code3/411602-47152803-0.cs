    public string ArrangeUsingRoslyn(string csCode) {
    	var tree = CSharpSyntaxTree.ParseText(csCode);
    	var root = tree.GetRoot().NormalizeWhitespace();
    	var ret = root.ToFullString();
    	return ret;
    }
