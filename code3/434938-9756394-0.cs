    Action externalFunction = null;
    public void RefreshLocalFM(Action action)
        {
            externalFunction = action;
        }
    // later code
    private void someMethod()
    {
       externalFunction();
    }
