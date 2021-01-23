    Tidy tidy = new Tidy();    
    TidyMessageCollection tmc = new TidyMessageCollection();
    MemoryStream input = new MemoryStream();
    MemoryStream output = new MemoryStream();
    tidy.Parse(input, output, tmc);
    //Same code than you
    foreach(TidyMessage message in tmc.MessageList)
    if (message.Level == MessageLevel.Error) 
    {
        // error handling here
    }
        
