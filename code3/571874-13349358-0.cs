    [Test]
    public void TaskExceptionTest()
    {
        var task = Task.Factory.StartNew(
            () =>
            {
                try
                {
                    throw new TargetInvocationException(null);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Caught one (inside):" + e.GetType().Name);
                }
            });
        try
        {
            task.Wait();
        }
        catch (AggregateException ae)
        {
            // Assume we know what's going on with this particular exception. 
            // Rethrow anything else. AggregateException.Handle provides 
            // another way to express this. See later example. 
            foreach (var e in ae.InnerExceptions)
            {
                if (e is TargetInvocationException)
                {
                    Console.WriteLine("After:" + e.GetType().Name);
                }
                else
                {
                    throw;
                }
            }
        }
    }
