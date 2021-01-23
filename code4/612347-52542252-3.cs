        public async static Task<long> DoAwaitTask()
        {
            stopWatch.Reset();
            stopWatch.Start();
            // [RUNS ON MAIN THREAD]
            await Task.Run(() => {
                Thread.Sleep(2000);
                // [RUNS ON WORKER THREAD]
            });
            // Waits until task is finished
            // [RUNS ON MAIN THREAD]
            stopWatch.Stop();
            return stopWatch.ElapsedMilliseconds;
        }
