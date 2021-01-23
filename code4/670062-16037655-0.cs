    public ASpecificWork()
    {
        // do A work
    }
    
    public BSpecificWork()
    {
        // do B work
    }
    
    public void Execute(Action action)
    {  
        Write();
        action();
        Clear();
    }
    Execute(BSpecificWork);
    Execute(ASpecificWork);
