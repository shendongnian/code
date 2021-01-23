    private static object InvokeOnChannel(IMethodInvocation methodInvocation)
    {
        var proxy = _factory.CreateChannel();
        var channel = (IChannel) proxy;
        try
        {
            channel.Open();
            dynamic result = methodInvocation.Method.Invoke(proxy, methodInvocation.Arguments);
            return Handle(result, channel);
        }
        catch (FaultException ex)
        {
            if (ex.InnerException != null)
                throw ex.InnerException;
            throw;
        }
        catch(Exception)
        {
            channel.Abort();
            throw;
        }
    }
    private static async Task Handle(Task task, IChannel channel)
    {
        try
        {
            await task;
            channel.Close();
        }
        catch (FaultException ex)
        {
            if (ex.InnerException != null)
                throw ex.InnerException;
            throw;
        }
        catch(Exception)
        {
            channel.Abort();
            throw;
        }
    }
    private static async Task<T> Handle<T>(Task<T> task, IChannel channel)
    {
        await Handle((Task)task, channel);
        return await task;
    }
    private static T Handle<T>(T result, IChannel channel)
    {
        channel.Close();
        return result;
    }
