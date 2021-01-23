    public async Task<IEnumerable<IEnumerable<T>>> GetBulkAsync<T>(
        Func<IGetter, Task<T>> selector) 
            where T : IEnumerable<T>
    {
        Task<T>[] tasks = new Task<T>[this.getters.Count];
        for (int i = 0; i < this.getters.Count; i++)
        {
            tasks[i] = selector(this.getters[i]);
        }
    
        T[] results = await Task.WhenAll(tasks);
    
        return results.Select(t => t.Result):
    }
