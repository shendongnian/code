    public void Check()
    {
       if (HasOrdered())
       {
          // do logic
       }
    }
    
    private bool HasOrdered()
    {
        return a && !b && !c;
    }
    
    private bool HasBooked()
    {
        return a && b && !c;
    }
