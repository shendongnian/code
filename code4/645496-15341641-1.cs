    class P
    {
        static void Main ()
        {
            System.Console.WriteLine(((dynamic)(Factory.Create())).Value);
        }
    }
-------------
    > csc foo.cs /r:bar.dll
    > foo
    Unhandled Exception: Microsoft.CSharp.RuntimeBinder.RuntimeBinderException: 
    'Thing' does not contain a definition for 'Value'
