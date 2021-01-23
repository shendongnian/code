    [Conditional("DEBUG")]
    public static void Assert(Expression<Func<bool>> assertion, string message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
    {
    	bool condition = assertion.Compile()();
    	if (!condition)
    	{
    		string errorMssage = string.Format("Failed assertion in {0} in file {1} line {2}: {3}", memberName, sourceFilePath, sourceLineNumber, assertion.Body.ToString());
    		throw new AssertionException(message);
    	}
    }
