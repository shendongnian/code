	public IEnumerable<MyClass> GetDescendants(MyClass node) {
		string currentLocation = node.HierarchyId;
		string followingSibling 
			= node.SqlHierarchyId.GetAncestor(1)
			      .GetDescendant(node.SqlHierarchyId, SqlHierarchyId.Null)
				  .ToString();
		return db.Select<MyClass>(n => n.HierarchyId > currentLocation 
									&& n.HierarchyId < followingSibling);
	}
