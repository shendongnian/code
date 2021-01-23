    public class Coordinator
    {
        private static object lockObj = new Object();
        public void initialize(InitializeArguments args)
        {
            lock(lockObj)
            {
                if (!args.Entity.IsInitialized)
                {
                ...
                }
            }
        }
    }
