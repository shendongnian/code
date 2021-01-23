    private static void Work(CancellationToken cancelToken)
    {
        while (true)
        {
            if(cancelToken.IsCancellationRequested)
            {
                return;
            }
            Console.Write("345");
        }
    }
