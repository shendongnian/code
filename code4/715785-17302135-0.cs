    public static Task<Item[]> Foo()
    {
        int total = result.paginationOutput.totalPages;
        var tasks = new List<Task<Item>>();
        for (int i = 2; i < total + 1; i++)
        {
            tasks.Add(Task.Factory.StartNew(() => client.findItemsByProduct(i)));
        }
        return Task.WhenAll(tasks);
    }
