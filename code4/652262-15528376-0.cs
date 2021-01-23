    static void Main(string[] args)
    {
      try
      {
        string s = GetStringData();
      }
      catch
      {
        // Exception is NOT caught here
      }
      Console.ReadLine();
    }
    public static string GetStringData()
    {
      MyAsyncMethod().ContinueWith(OnMyAsyncMethodFailed, TaskContinuationOptions.OnlyOnFaulted);
      return "hello world";
    }
    public static async Task MyAsyncMethod()
    {
      await Task.Run(() => { throw new Exception("thrown on background thread"); });
    }
    public static void OnMyAsyncMethodFailed(Task task)
    {
      Exception ex = task.Exception;
      // Deal with exceptions here however you want
    }
