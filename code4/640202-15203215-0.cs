    private static MethodInfo handleAsync = ...; // point this to HandleAsync<T>
    // Only called if the return type is Task/Task<T>
    private static object InvokeAsyncOnChannel(IMethodInvocation methodInvocation)
    {
        var proxy = _factory.CreateChannel();
        var channel = (IChannel) proxy;
        try
        {
            channel.Open();
            var task = methodInvocation.Method.Invoke(proxy, methodInvocation.Arguments) as Task;
            object ret;
            if (task.GetType() == typeof(Task))
                ret = HandleAsync(task, channel);
            else
                ret = handleAsync.MakeGenericMethod(task.GetType().GetGenericParameters()).Invoke(this, task, channel);
            return ret;
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
    private static async Task HandleAsync(Task task, IChannel channel)
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
    private static async Task<T> HandleAsync<T>(Task task, IChannel channel)
    {
        try
        {
            var ret = await (Task<T>)task;
            channel.Close();
            return ret;
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
