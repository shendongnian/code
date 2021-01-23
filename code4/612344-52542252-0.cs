        public static void DoSomeWork()
        {
            var task = Task.Run(() =>
            {
                // [RUNS ON WORKER THREAD]
                // IS NOT bubbling up due to the different threads
                throw new Exception();
                Thread.Sleep(2000);
                
                return "Hello";
            });
            // This is the callback
            task.ContinueWith((t) => {
                // -> Exception is swallowed silently
                Console.WriteLine("Completed");
                // [RUNS ON WORKER THREAD]
            });
        }
