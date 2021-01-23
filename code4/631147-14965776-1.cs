    public async Task MyMethod()
    {
        Task t = MethodIDontOwnThatReturnsTask();
        try
        {
            await t;
        }
        catch(Exception e)
        {
            throw Tweak(e);
        }
    }
