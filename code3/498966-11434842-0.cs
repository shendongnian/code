    public void DoMultiOperations(Foo param, Action<IEnumerable<Bar>> callback)
    {
        var allResults = new List<Bar>();
        IList<IProcessor> processorList;
        if ((processorList = processors as IList<IProcessor>) != null)
        {
            var taskFactory = new TaskFactory<IEnumerable<Bar>>(
                TaskCreationOptions.None,
                TaskContinuationOptions.ExecuteSynchronously);
            foreach (IProcessor t in processorList)
            {
                IProcessor processor = t;
                taskFactory
                    .StartNew(() => processor.Provide(param))
                    .ContinueWith(task => allResults.AddRange(task.Result))
                    .Wait(5 * 1000);
            }
        }
        callback(allResults);
    }
