    public ITargetBlock<string> SearchPipeline()
    { 
        var search = new TransformBlock<string, IEnumerable<FileInfo>>(path =>
            {
                try
                {
                    return Search(path);
                }
                catch (OperationCanceledException)
                {
                    return null;
                }
            });
        var move = new ActionBlock<IEnumerable<FileInfo>>(files =>
            {
                try
                {
                    Move(files);
                }
                catch (OperationCanceledException)
                {
                    // swallow the exception; we don't want to fault the block
                }
            });
        var operationCancelled = new ActionBlock<object>(_ => form._update(),
            new ExecutionDataflowBlockOptions
            {
                TaskScheduler = TaskScheduler.FromCurrentSynchronizationContext()
            });
        search.LinkTo(move, files => files != null);
        search.LinkTo(operationCancelled);
        return search;
    }
