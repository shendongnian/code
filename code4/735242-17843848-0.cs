    public static SeparatedSyntaxList<T> ToSeparatedList<T>(
        this IEnumerable<T> nodes, SyntaxKind separator = SyntaxKind.CommaToken)
        where T : SyntaxNode
    {
        var nodesList = nodes == null ? new List<T>() : nodes.ToList();
        return Syntax.SeparatedList(
            nodesList,
            Enumerable.Repeat(
                Syntax.Token(separator), Math.Max(nodesList .Count - 1, 0)));
    }
