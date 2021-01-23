    public bool isOrHasGrouping<T>(IEnumerable<T> coll)
    {
      	return
            typeof(T).Name.Contains("IGrouping") 
                ? true
        	: (typeof(T).ContainsGenericParameters 
        	    ? typeof(T).GenericTypeArguments
                        .Any(item => item.Name.Contains("IGrouping")) 
        	    : false);
     }
