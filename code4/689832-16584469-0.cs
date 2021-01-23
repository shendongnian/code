    async static Task Test()
    {
        Task containingTask, nullRefTask, argTask;
        try
        {
            containingTask = Task.Factory.StartNew(() =>
            {
                nullRefTask = Task.Factory.StartNew(() =>
                {
                    throw new NullReferenceException();
                }, TaskCreationOptions.AttachedToParent);
                argTask = Task.Factory.StartNew(() =>
                {
                    throw new ArgumentException();
                }, TaskCreationOptions.AttachedToParent);
            });
            await containingTask;
        }
        catch (AggregateException ex)
        {
            Console.WriteLine("** {0} **", ex.GetType().Name);
        }
    }
