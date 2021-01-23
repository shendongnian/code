    //Collection to hold the data the processed files generated
    var proccesedDataItems = new new BlockingCollection<ResultData>();
    
    //A thread that processes the files
    var processReports = new Task(() =>
    {
        //Removes items from the collection, if the collection is empty it blocks
        // or if "CompletedAdded" has been called it will reach the "end" of the 
        // collection
        foreach(var processedData in proccesedDataItems.GetConsumingEnumerable())
        {
            BuildReport(processedData);
        }
    });
    processReports.Start();    
    //Generating the data
    Parallel.Foreach(files, file => 
    {
       var proccesedData = ProcessFile(file)
       proccesedDataItems.Add(processedData);
    });
    
    //Let anyone consuming the collection that you can stop waiting for new items.
    proccesedDataItems.CompleteAdding();
