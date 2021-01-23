	public static Type FindEqualTypeWith(this Type typeLeft, Type typeRight) {
		if(typeLeft==null||typeRight==null)
			return null;
		var typeLeftUion=typeLeft.GetInterfaceHierarchy().Union(typeLeft.GetClassHierarchy());
		var typeRightUion=typeRight.GetInterfaceHierarchy().Union(typeRight.GetClassHierarchy());
		return 
			typeLeftUion.Intersect(typeRightUion)
				.OrderByDescending(interfaceInHierarhy => interfaceInHierarhy.GetInterfaces().Contains(typeof(IEnumerable)))
				.ThenByDescending(interfaceInHierarhy => interfaceInHierarhy.Equals(typeof(IEnumerable)))
				.FirstOrDefault();
	}
