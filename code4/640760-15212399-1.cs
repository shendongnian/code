    using System.Diagnostics;
    class Foo
    {
        [DebuggerStepThrough]
        int Bar()
        {
            return 10;
        }
    }
