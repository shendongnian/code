        public void DoMultiOperations(Foo param, Action<IEnumerable<Bar>> callback)
        {
            var allResults = new ConcurrentQueue<Bar>();
            Parallel.ForEach(processors, processor =>
            {
                var enumerable = processor.Provide(param);
                foreach (var bar in enumerable)
                    allResults.Enqueue(bar);
            });
            callback(allResults);
        }
