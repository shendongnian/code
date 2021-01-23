    private static IEnumerable<INamespaceSymbol> GetNamespaceSymbol(ISymbol symbol)
    {
        if (symbol != null && symbol.ContainingNamespace != null)
            yield return symbol.ContainingNamespace;
    }
    
    var ns = semanticModel.SyntaxTree.Root.DescendentNodes().SelectMany(node =>
        GetNamespaceSymbol(semanticModel.GetSemanticInfo(node).Symbol)).Distinct();
