    public void DoWhatever()
    {
        DoAction(DoingWhatever);
    }
    private void DoingWhatever()
    {
        // ...
    }
    private void DoAction(Action action)
    {
        methodToPrepareEnvironment();
    
        action();
    
        methodToResumeEnvironment();
    }
