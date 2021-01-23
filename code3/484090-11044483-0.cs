    DateTime lastActionTime = DateTime.Now;
    
    // ...
    
    if ((DateTime.Now - lastActionTime).Milliseconds < 1000)
    {
        // Too soon to execute the action again
        return;
    }
    // Do whatever the action does...
