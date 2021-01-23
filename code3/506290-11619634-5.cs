    public void DoAction(Action action)
    {
        // Make the boilerplate code whatever you need it to be. 
        // I've just used a try catch for simplicity.
        try
        {
            // Call the action at the appropriate time.
            action();
        }
        catch
        {
            // Handle any exceptions as you wish.
        }
    }
