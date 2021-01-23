    var collection = new BlockingCollection<string>(); //You may want to set a max size so you don't use up all your memory
    Task producer = Task.Run(() =>
    {
        foreach(var file in Directory.GetFiles(someSearch)
        {
             collection.Add(File.ReadAllText(file))
        }
        collection.CompleteAdding();
    });
    Parallel.ForEach(collection.GetConsumingEnumerable(), ProcessText); //Make sure any actions ProcessText does (like incrementing any variables in the class) is done in a thread safe manner.
