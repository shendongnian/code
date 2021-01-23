    public void SomeMethodCalledDuringSession()
    {
        using(var resourceHog = new ResourceHog()) // where ResourceHog : IDisposable
        {
            // Perform operations
        }
    }
