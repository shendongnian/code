    for (int i = currentMission.ActiveTriggers.Count - 1; i >= 0; i--)
    {
        // Run() is an abstract method on Trigger
        currentMission.ActiveTriggers[i].Run();
    }
