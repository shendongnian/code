    public override void Install(System.Collections.IDictionary stateSaver)
    {
        if (CheckForExceptionalCondition())
            throw new InstallException("Some message for user.");
        
        base.Install(savedState);
    }
