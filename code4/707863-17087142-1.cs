    public static class Extensions
    {
        public static Task ExecuteInGroupsAsync<T>(
             this IEnumerable<T> source, Func<T, Task> func, int groupSize)
         {
             var block = new ActionBlock<IEnumerable<T>>(
                 g => Task.WhenAll(g.Select(func)));
             source.ToObservable()
                   .Buffer(groupSize)
                   .Subscribe(block.AsObserver());
             return block.Completion;
         }
    }
    public Task ProcessFiles(IEnumerable<File> files)
    {
        return files.ExecuteInGroupsAsync(Upload, 10);
    }
