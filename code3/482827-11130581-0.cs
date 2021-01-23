    static void Main(string[] args)
    {
        var logExceptionMethod = typeof (Program).GetMethod("LogException", BindingFlags.Static | BindingFlags.NonPublic);
        var createFileMethod = typeof (System.IO.File).GetMethod("Create", new[] {typeof(string)});
        // Parameter for the catch block
        var exception = Expression.Parameter(typeof(Exception));
        var expression =
            Expression.TryCatch(
            Expression.Block(typeof(void),
                // Try to create an invalid file
                Expression.Call(createFileMethod, Expression.Constant("abcd/\\"))),
                // Log the exception from the catch                  
                Expression.Catch(exception, Expression.Call(logExceptionMethod, exception)));
        Expression.Lambda<Action>(expression).Compile()();
    }
    static void LogException(Exception ex)
    {
        Console.WriteLine(ex.Message + "\r\n" + ex.StackTrace);
    }
