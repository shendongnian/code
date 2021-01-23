        public static void DoSomething()
        {
            doSomethingCount++;
            if (doSomethingTask == null || doSomethingTask.IsCompleted)
            {
                doSomethingTask = Task.Run((Action)() =>
                {
                    while (doSomethingCount > 0)
                    {
                        DoSomethingAction();
                        doSomethingCount--;
                    }
                });
            }
        }
        private static void DoSomethingAction()
        {
            throw new NotImplementedException();
        }
        private static Task doSomethingTask;
        private static int doSomethingCount = 0;
