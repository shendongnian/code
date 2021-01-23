    [DebuggerHidden]
    public static void Contains(File file, string text){
        if(!ContainText(file, text)){
            HandleFail("MyAssert.Contains", null, null);
        }
    }
    [DebuggerHidden]
    private static void HandleFail(string assertName, string message, params object[] parameters )
    {
        message = message ?? String.Empty;
        if (parameters == null)
        {
            throw new AssertFailedException(String.Format("{0} failed. {1}", assertName, message));
        }
        else
        {
            throw new AssertFailedException(String.Format("{0} failed. {1}", assertName, String.Format(message, parameters)));
        }
    }
