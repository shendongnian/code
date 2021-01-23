    private async Task Run()
    {
        IEnumerable<Item> items = repo.GetItems(); // sync method to get list from database
        foreach (var task in items.Select(item => GetFromWeb(item.url))
            .Order())
        {
            await task.ConfigureAwait(false);
            AddToDatabase(task.Result);
        }
    }
