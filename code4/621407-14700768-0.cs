    public class Whatever
    {
        public void DoSomething()
        {
            string foo = "blah"; // Breakpoint hit and execution stopped here.
            // Do something.
            DoSomethingElse();
        }
        public void DoSomethingElse()
        {
            string bar = "yack";
            // Do something else.
        }
    }
