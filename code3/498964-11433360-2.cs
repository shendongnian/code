        private IEnumerable<IProcessor> processors;
        public void DoMultiOperations(Foo param, Action<IEnumerable<Bar>> callback)
        {
            var allResults = new ConcurrentQueue<Bar>();
            Task.WaitAll(processors.Select(processor => Task.Factory.StartNew(() => GetData(processor, param, allResults))).ToArray());
            callback(allResults);
        }
        private static void GetData(IProcessor processor, Foo param, ConcurrentQueue<Bar> allResults)
        {
            var enumerable = processor.Provide(param);
            foreach (var bar in enumerable)
            {
                allResults.Enqueue(bar);
            }
        }
