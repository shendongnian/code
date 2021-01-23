	var updateMember = new Dictionary<MemberDeclarationSyntax, MemberDeclarationSyntax>();
	var addMembers = new List<MemberDeclarationSyntax>();
	foreach (var m in matching) {
		if (m.A != null && m.B != null && m.O != null) {
			var mergeChild = Merge(m.A, m.B, M.O);
			updateMember.Add(m.O, child);
		}
		else if (m.A == null && m.O == null && m.B != null) 
			addMembers.Add(m.B);
		else if (m.A != null && m.O == null && m.B == null)
			addMembers.Add(m.A);
	}
	var merged = O.ReplaceNodes(updateMember.Keys.AsEnumerable(), (n1, n2) =>
	{
		return updateMember[n1];
	}).AddMembers(addMembers.ToArray());
