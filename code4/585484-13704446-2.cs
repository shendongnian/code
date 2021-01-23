    private static AsyncLock mutex = new AsyncLock();
    private static async Task Writer(int num)
    {
      using (await mutex.LockAsync())
      {
        Console.WriteLine("start " + num);
        await Task.Delay(500);
        Console.WriteLine("end " + num);
      }
    }
