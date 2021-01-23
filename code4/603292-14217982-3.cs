    List<ISteppable> list = new List<ISteppable>();
    
    list.Add(new StepAdapter(new step(){StepNumber = 5}));
    list.Add(new AutoStepAdapter(new AutoStep(){StepNumber = 3}));
    
    list.Sort((a, b) => a.StepNumber.CompareTo(b.StepNumber));
    
    foreach (var item in list)
    {
        item.Foo();
    }
