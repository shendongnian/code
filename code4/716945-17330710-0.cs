    private void HandleErrorsFor(Action action)
    {
        try
        {
            action();
        }
        catch (Exception ex)
        {
            //repeated exception handling...
        {
    }
    //...
    public void DoSomething()
    {
        HandleErrorsFor(() => {
            //try block #1
        });
        HandleErrorsFor(() => {
            //try block #2
        });
    }
