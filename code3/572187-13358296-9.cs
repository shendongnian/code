        Task<int> task = new Task<int>(Test);
        task.Start();
        try
        {
            task.Wait();
        }
        catch (AggregateException ex)
        {
            Console.WriteLine(ex);
        }
