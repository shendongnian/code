    class step : IStep
    {
       ...
       public int StepNumber {get; set;}
    }
    
    class AutoStep : IStep
    {
       ...
       public int StepNumber {get; set;}
    }
    
    interface IStep
    {
       public int StepNumber;
    }
    List<IStep> steps; // list with steps and autosteps
    List<IStep> orderedSteps = steps.OrderBy(s => s.StepNumber);
    foreach (IStep step in orderedSteps)
    {
      if (step is Step)
        // call to method here
      else if (step is AutoStep)
        // call to other method here
    }
