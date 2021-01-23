    var task = Task.Factory.StartNew(
        () => GetDatabaseData(someArguments),
        TaskCreationOptions.LongRunning);
    // Example method
    public DataSet GetDatabaseData(object args) { ... }
