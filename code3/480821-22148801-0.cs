    // using System.Runtime.CompilerServices 
    // using System.Diagnostics; 
    
    public void DoProcessing()
    {
        TraceMessage("Something happened.");
    }
    
    public void TraceMessage(string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
    {
        Trace.WriteLine("message: " + message);
        Trace.WriteLine("member name: " + memberName);
        Trace.WriteLine("source file path: " + sourceFilePath);
        Trace.WriteLine("source line number: " + sourceLineNumber);
    }
    
    // Sample Output: 
    //  message: Something happened. 
    //  member name: DoProcessing 
    //  source file path: c:\Users\username\Documents\Visual Studio 2012\Projects\CallerInfoCS\CallerInfoCS\Form1.cs 
    //  source line number: 31
