    void Main()
    {
    	var argLeft = Expression.Constant("Foobar", typeof(string));
    	var argRight = Expression.Constant("F%b%r", typeof(string));
    	
    	var likeExpression = Expression.Call(typeof(StringHelper), "Like", null, argLeft, argRight);
    					
    	Expression.Lambda(likeExpression).Compile().DynamicInvoke().Dump();
    }
    public static class StringHelper
    {
    	public static bool Like(string toSearch, string toFind)
    	{
    		return new Regex(@"\A" + new Regex(@"\.|\$|\^|\{|\[|\(|\||\)|\*|\+|\?|\\").Replace(toFind, ch => @"\" + ch)
    																				  .Replace('_', '.')
    																				  .Replace("%", ".*") + @"\z", 
    						 RegexOptions.Singleline).IsMatch(toSearch);
    	}
    }
