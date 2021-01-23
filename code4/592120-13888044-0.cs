    static SyntaxNode GetNode(SyntaxTree tree, int lineNumber)
    {
        var lineSpan = tree.GetText().GetLineFromLineNumber(lineNumber - 1).Extent;
        return tree.GetRoot().DescendantNodes(lineSpan)
                   .First(n => lineSpan.Contains(n.Span));
    }
