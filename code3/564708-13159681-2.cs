    [SerivceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    class MyService : IMyContract
    {
    //Here is your shared object
    static List<string> _strList = new List<string>();
    //Only access the property for thread safety, not the variable
    static List<string> StrList
    {
        get
        {
            lock(typeof(MyService)
            {
                return _strList;
            }
        }
        set
        {
            lock(typeof(MyService)
            {
                _strList = value;
            }
        }
    }
    
    void DoSomeThing()
    {
        lock(typeof(MyService))
        {
            //Do something with your list here, other threads are blocked from accessing
            // objects in lock
            StrList.Add("Something");
        }
    }
    }
