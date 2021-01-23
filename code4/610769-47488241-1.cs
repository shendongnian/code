    public delegate void ToEachTransformAction<T>(ref T Telement);
    
    [Extension()]
    public static void ToEach<T>(Generic.IList<T> thislist, ToEachTransformAction<T> Transform)
    	{
    		for (var n = 0; n < thislist.Count; n++)
    		{
    			Transform.Invoke(thislist(n));
    		}
    	}
