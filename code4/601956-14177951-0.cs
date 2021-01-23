    public static async Task Task1()
    {
      await Task.Factory.StartNew(() => Thread.Sleep(TimeSpan.FromSeconds(5)));
      Debug.WriteLine("Finished Task1");
    }
    public static async Task Task2()
    {
      await Task.Factory.StartNew(() => Thread.Sleep(TimeSpan.FromSeconds(10)));
      Debug.WriteLine("Finished Task2");
    }
