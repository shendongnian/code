    using System.Runtime.CompilerServices;
 
    ...
    public Foo Bar1(
        Action, 
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
    {
        ...
    }
