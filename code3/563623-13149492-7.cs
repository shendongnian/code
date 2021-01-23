    async void Caller()
    {
        // Synchronously get a list of Tasks
        IEnumerable<Task<SomeClass>> items = GetStuff();
        // Iterate through the Tasks
        foreach (Task<SomeClass> itemAsync in items)
        {
            // Wait for the task to complete. We need to wait for 
            // it to complete before we can know if it's the end of
            // the sequence
            SomeClass item = await itemAsync;
            // End of sequence?
            if (item == null) 
                break;
            Console.WriteLine(item);
        }
    }
