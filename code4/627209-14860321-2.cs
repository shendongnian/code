    public async Task MethodC() //you can change the signature to return `void` if this is an event handler
    {
        try
        {
            await semaphore.WaitAsync();
            //Do stuff
        }
        finally
        {
            semaphore.Release();
        }
    }
