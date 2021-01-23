    public static class SomeClassExtensions
    {
        public static Task DoPeriodicWorkAsync(
                                           this SomeClass someInstruction,
                                           TimeSpan dueTime, 
                                           TimeSpan interval, 
                                           CancellationToken token)
        {
            //Create and return the task here
        }
    }
