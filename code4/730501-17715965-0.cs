    private void getWorkingChanged(object c)<<--This is where i wont c to be multiple objects
    {
        IEnabler ie = c as IEnabler;
        if(ie != null)
           ie.Enable();
    }
