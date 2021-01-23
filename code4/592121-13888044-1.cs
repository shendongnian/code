    static SyntaxNode GetNode(SyntaxTree tree, int lineNumber)
    {
        var lineSpan = tree.GetText().Lines[lineNumber - 1].Span;
        return tree.GetRoot().DescendantNodes(lineSpan)
            .First(n => lineSpan.Contains(n.Span));
    }
