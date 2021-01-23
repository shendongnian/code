    var messages = GetAllMessages(); //goes to DB
    
    Parallel.ForEach(
        messages,
        new ParallelOptions { MaxDegreeOfParallelism = threadCount },
        message => { /* your code that calls the web service */ });
    
    UpdateAll(messages); // goes back to the DB
