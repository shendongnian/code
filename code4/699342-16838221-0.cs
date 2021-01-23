    // System.RuntimeType
    private static void FilterHelper(BindingFlags bindingFlags, ref string name, bool allowPrefixLookup, out bool prefixLookup, out bool ignoreCase, out RuntimeType.MemberListType listType)
    {
    	prefixLookup = false;
    	ignoreCase = false;
    	if (name != null)
    	{
    		if ((bindingFlags & BindingFlags.IgnoreCase) != BindingFlags.Default)
    		{
    			name = name.ToLower(CultureInfo.InvariantCulture);
    			ignoreCase = true;
    			listType = RuntimeType.MemberListType.CaseInsensitive;
    		}
    		else
    		{
    			listType = RuntimeType.MemberListType.CaseSensitive;
    		}
    		if (allowPrefixLookup && name.EndsWith("*", StringComparison.Ordinal))
    		{
    			name = name.Substring(0, name.Length - 1);
    			prefixLookup = true;
    			listType = RuntimeType.MemberListType.All;
    			return;
    		}
    	}
    	else
    	{
    		listType = RuntimeType.MemberListType.All;
    	}
    }
