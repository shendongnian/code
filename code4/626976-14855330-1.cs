    async Task MyMethod()
    {
        try
        {
            await Task.Run(
                () =>
                {
                    // Some work.
                });
        }
        catch (SomeException ex)
        {
        }
    }
