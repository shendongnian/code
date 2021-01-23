    private void TimerElapsedCallback(object sender, ElapsedEventArgs e)
    {
        try
        {
            this.DoSomething();
        }
        catch (Exception ex)
        {
            // handle
        }
    }
    private void DoSomething()
    {
        // logic goes here and can be agnostic of any exceptions it throws, if desired
    }
