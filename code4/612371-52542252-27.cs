        public static long DoTask()
        {
            stopWatch.Reset();
            stopWatch.Start();
            // [RUNS ON MAIN THREAD]
            var task = Task.Run(() => {
                Thread.Sleep(2000);
                // [RUNS ON WORKER THREAD]
            });
            // goes directly further
            // WITHOUT waiting until the task is finished
            // [RUNS ON MAIN THREAD]
            stopWatch.Stop();
            // 50 milliseconds
            return stopWatch.ElapsedMilliseconds;
        }
