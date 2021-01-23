    // Assuming you have a work queue defined as 
    public static BlockingCollection<Action<Session>> myWorkQueue = new BlockingCollection<Action<Session>>();
    // and your eventargs looks something like this
    public class MyObjectUpdatedEventArgs : EventArgs {
        public MyObject MyObject { get; set; }
    }
    
    // And one of your event handlers
    public MyObjectWasChangedEventHandler(object sender, MyObjectUpdatedEventArgs e) {
        myWorkQueue.Add(s=>SaveOrUpdate(e.MyObject);
    }
    // Then a thread in a constant loop processing these items could work:
    public void ProcessWorkQueue() {
        var mySession = mySessionFactory.CreateSession();
        while (true) {
            var nextWork = myWorkQueue.Take();
            nextWork(mySession);
        }
    }
    // And to run the above:
    var dbUpdateThread = new Thread(ProcessWorkQueue);
    dbUpdateThread.IsBackground = true;
    dbUpdateThread.Start();
