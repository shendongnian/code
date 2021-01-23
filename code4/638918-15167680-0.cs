    SemaphoreSlim mutex = new SemaphoreSlim(1);
    private static async Task doThingAsync(object i)
    {
        await mutex.WaitAsync();
        try
        {
            Console.WriteLine("in do thing {0}", (int)i);
            await Task.Delay(TimeSpan.FromSeconds(5));
            Console.WriteLine("out of do thing {0}", (int)i);
        }
        finally
        {
            mutex.Release();
        }
    }
