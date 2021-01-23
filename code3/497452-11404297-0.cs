    private static Dictionary<TimeStep, bool> steps = new Dictionary<TimeStep,bool>();
    
    public static bool CheckActiveAddIfNew(TimeStep step)
    {
        //Assumes synchronization logic
        bool isActive;
        if(!steps.TryGetValue(step, out isActive)
        {
           steps.Add(step, true);
           isActive = true;
        }
        return isActive;
    }
    public static bool ChangeFilter(TimeStep oldSetp, TimeStep newStep)
    {
       //Synchronization code
       bool ableToChange;
       if(!CheckActiveAddIfNew(newStep))
       {
           steps[newStep] = true;
           steps[oldStep] = false;
           ableToChange = true;
       }
       
       return ableToChange;
    }
