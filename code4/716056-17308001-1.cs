    public static class MyStringLiteralBuilder
    {
    	private static readonly string StringLiteral = 
    @"This {0} a really long string literal
    I don't want {1} to have {2} at 
    the beginning of each line, so I have
    to break the indentation  of my program";
    
    	public static string Build(object var1, object var2, object var3)
    	{
    		return String.Format(MyStringResources.StringLiteral, var1, var2, var3);
    	}
    }
