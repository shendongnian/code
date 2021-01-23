    private int loadCounter;
    private void LoadinDatagrid()
    {   
        loadCounter = 3;
        IsBusy = true;
        GetResult = DomainContext.Current.Load(GetSomething1Query(), LoadCompleted);
        GetResult = DomainContext.Current.Load(GetSomething2Query(), LoadCompleted);
        GetResult = DomainContext.Current.Load(GetSomething3Query(), LoadCompleted);         
    }
    private void LoadCompleted(LoadOperation result)
    {
        Interlocked.Decrement(loadCounter); // Thread save decrementing
        if(loadCounter == 0) // All queries have been loaded
        {
            IsBusy = false;
        }
    }
