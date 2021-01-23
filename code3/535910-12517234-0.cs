	private static SyntaxList<MemberDeclarationSyntax> AddBeforeIfDirective(
		SyntaxList<MemberDeclarationSyntax> oldMembers,
		MemberDeclarationSyntax newMember)
	{
		var ifIndex = oldMembers.IndexOf(
			member => member.GetLeadingTrivia()
				.Any(t => t.Kind == SyntaxKind.IfDirective));
		return oldMembers.Insert(ifIndex, newMember);
	}
	…
	var newMembers = AddBeforeIfDirective(theClass.Members, field);
	theClass = theClass.WithMembers(newMembers).NormalizeWhitespace();
