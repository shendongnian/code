    public TFinal MakeMeA<TOuter,TInner,TInnermost,TFinal>(params object[] additionalCrap)
    {
    	// figure out innermost type
    	var innermostType = typeof(TInner).MakeGenericType(typeof(TInnermost));
    	// work outwards
    	var nextLevel = typeof(TOuter).MakeGenericType(innermostType);
    	// figure out what the heck we're making
    	var returnType = typeof(TFinal).MakeGenericType(nextLevel);
    	
    	// And make one of those	
    	return (TFinal)Activator.CreateInstance(returnType, additionalCrap);
    }
