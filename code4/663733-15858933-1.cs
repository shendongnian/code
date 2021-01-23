	public static string dump(Object t)
	{
	    Type type = t.GetType();
	    if (type.IsGenericType) { // a generic type
		Type[] types2 = type.GetGenericArguments(); // types of the generic parameters
		if (types2.Length == 1) { // just one type...t is List<X>
		    return dumpEnumerable(t as System.Collections.IList);
		} else if (types2.Length == 2) { // two types...t is Dictionary<K,V>
		    return dumpKeyValuepair(type.GetProperty("Key").GetValue(t, null),
					    type.GetProperty("Value").GetValue(t, null));
		} else {
		    // ??
		    return "?";
		}
	    } else { // not a generic
		return t.ToString();
	    }
	}
