    internal static SyntaxList<UsingDirectiveSyntax> Sort(this SyntaxList<UsingDirectiveSyntax> usingDirectives, bool placeSystemNamespaceFirst = false) =>
        SyntaxFactory.List(
            usingDirectives
            .OrderBy(x => x.StaticKeyword.IsKind(SyntaxKind.StaticKeyword) ? 1 : x.Alias == null ? 0 : 2)
            .ThenBy(x => x.Alias?.ToString())
            .ThenByDescending(x => placeSystemNamespaceFirst && x.Name.ToString().StartsWith(nameof(System) + "."))
            .ThenBy(x => x.Name.ToString()));
