    private static void getImplementedTypes(Type baseType, Assembly assembly, IList<Type> list) {
		Type[] types = assembly.GetExportedTypes();
		foreach (Type t in types) {
			if (baseType.IsInterface) {
				Type[] interfaces = t.GetInterfaces();
				foreach (Type i in interfaces) {
					if (i == baseType) list.Add(t);
				}
			}
			else {
				if ((!list.Contains(t)) && (t.IsSubclassOf(baseType)) && (!t.IsAbtract)) {
  					list.Add(t);
    			}
			}
		}
		return n;
	}
