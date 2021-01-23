    public void TestMyLoop()
    {
        
        var myLooper = new Looper();
        
        Task t = Task.Run(() => myLooper.BeginWorking());  // BeginWorking is an infinite loop, it will never end!
        
        myLooper.AddAnItemToProcess(new Item());
    
        Thread.Sleep(5000); // wait 5 seconds, alternatively hook into and `await` some completion event.
        
        // assert here
        Assert.That(myLooper.processedItems == 1);
        
     }
