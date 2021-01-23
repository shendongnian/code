    /// <param name="wantedTypes">--- Sample: --- new Type[] { typeof(Label), typeof(Button) }</param>
    public static IEnumerable OfTypes(this IEnumerable collection, Type[] wantedTypes)
    {
    	if (wantedTypes == null)
    		return null;
    	else
    		return collection.Cast<object>().Where(element => wantedTypes.Contains(element.GetType()));
    }
