        public void DoMultiOperations(Foo param, Action<IEnumerable<Bar>> callback)
        {
            ConcurrentBag<Bar> allResults = new ConcurrentBag<Bar>();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Parallel.ForEach(this.processors, (processor, loopState) =>
            {
                foreach (Bar item in processor.Provide(param))
                {
                    allResults.Add(item);
                }
                if (sw.ElapsedMilliseconds > 15000)
                {
                    loopState.Stop();
                    throw new TimeoutException();
                }
            });
            callback(allResults);
        }
