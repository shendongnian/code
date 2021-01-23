    IFeed feedOne = new SomeFeed();
    IFeed feedTwo = new SomeFeed();
    
    var t1 = Task.Factory.StartNew(() => { feedOne.SendData(); });
    
    var t2 = Task.Factory.StartNew(() => { feedTwo.SendData(); });
    
    // Waits for all provided tasks to finish execution
    Task.WaitAll(t1, t2);
