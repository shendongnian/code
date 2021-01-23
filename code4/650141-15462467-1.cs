    private bool isComplete = false;
    private object DataStoreLock = new object();
    private List<MyCustomClass> myDataStore;
    private Timer myTimer;
    public void ProcessData()
    {
        myTimer = new Timer(SaveData, null, TimeSpan.Zero, TimeSpan.FromMinutes(5.0));
        foreach (var item in File.ReadLines(path))
        {
            var myData = new MyCustomClass()
                {
                    ID = 0, // Some code here
                    Name = "Some code here",
                    Age = 0 // Some code here
                };
            lock (DataStoreLock)
            {
                myDataStore.Add(myData);
            }
        }
        isComplete = true;
    }
    public void SaveData(object arg)
    {
        // Our first step is to check if timed work is done.
        if (isComplete)
        {
            myTimer.Dispose();
            myTimer = null;
        }
        // Our next step is to create a local instance of the data store to work on, which
        // allows ProcessData to continue populating while our DB actions are being performed.
        List<MyCustomClass> lDataStore;
        lock (DataStoreLock)
        {
            lDataStore = myDataStore;
            myDataStore = new List<MyCustomClass>();
        }
        //Some code DB code here.
    }
