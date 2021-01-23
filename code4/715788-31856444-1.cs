    private async Task<List<T>> FindItems(...)
    {
        int total = result.paginationOutput.totalPages;
        var tasks= new List<Task<IEnumerable<T>>>();
        
        // start all tasks. don't wait for the result yet
        for (int i = 2; i < total + 1; i++)
        {
            Task<IEnumerable<T>> task = Task.Factory.StartNew(() =>
            {
                return client.findItemsByProduct(i);
            });
            tasks.Add(task);
        }
        // now that all tasks are started, wait until all are finished
        await Task.WhenAll(tasks);
        // the result of each task is now in task.Result
        // the type of result is IEnumerable<T>
        // put all into one big list using some linq:
        return tasks.SelectMany ( task => task.Result.SearchResult.Item)
            .ToList();
        // if you're not familiar to linq yet, use a foreach:
        var newList = new List<T>();
        foreach (var task in tasks)
        {
            newList.AddRange(task.Result.searchResult.item);
        }
        return newList;
    }
