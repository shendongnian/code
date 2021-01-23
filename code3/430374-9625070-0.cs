    static SyntaxTree UpdatePredefinedTypes(this SyntaxTree tree)
    {
        PredefinedTypeSyntax node;
        var root = tree.Root;
        while (null != (node = root.DescendentNodes()
                                   .OfType<PredefinedTypeSyntax>()
                                   .FirstOrDefault(
                                     syn => redefineMap.ContainsKey(syn.PlainName))))
        {
            var ident = Syntax.IdentifierName(redefineMap[node.PlainName]);
            root = root.ReplaceNode<SyntaxNode, SyntaxNode>(
                node, 
                ident.WithLeadingTrivia(node.GetLeadingTrivia())
                     .WithTrailingTrivia(node.GetTrailingTrivia()));
        }
        return SyntaxTree.Create(tree.FileName, root, tree.Options);
    }
