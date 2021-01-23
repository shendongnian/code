    public void RunSwitchables()
    {
       bool runCatchAll = true;
       foreach(var switched in SwitchableActions.Where(a => a.Predicate())
       {
         switched.TheAction();
         runCatchAll = false;
       }
       if(runCatchAll)
         //TODO: Something else.
    }
    
