    async void Caller()
    {
        // Calls get-stuff, which returns immediately with a Task
        Task<IEnumerable<SomeClass>> itemsAsync = GetStuff();
        // Wait for the task to complete so we can get the items
        IEnumerable<SomeClass> items = await itemsAsync;
        // Iterate synchronously through the items which are all already present
        foreach (SomeClass item in items)
        {
            Console.WriteLine(item);
        }
    }
