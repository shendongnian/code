    // Set(): effectively lock the system clock at a specific time
    SystemTime.Set(new DateTime(2015, 1, 1));
    
    RunCodeThatFetchesDataAndCachesIt();
    
    // MoveForward(): easily move the clock relative to current time with an
    //  arbitrary TimeSpan
    SystemTime.MoveForward(TimeSpan.FromMinutes(1));
    
    RunCodeThatFetchesDataAndCachesIt();
    VerifyExpectationThatDataWasFetchedTwice();
    
    // Reset(): return to the normal behavior of returning the current
    //   DateTime.Now value
    SystemTime.Reset();
