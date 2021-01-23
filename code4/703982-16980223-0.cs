    public static TResult Using<T, TResult>(this T client, Func<T, TResult> work) where T : ICommunicationObject
    {
        TResult res = default(TResult);
        try
        {
            res = work(client);
            client.Close();
        }
        catch (CommunicationException)
        {
            client.Abort();
                throw;
        } // ... more catch cases might go here... 
        finally
        {
            if (client.State != CommunicationState.Closed)
                client.Abort();
        }
        return res;
    }
