    public static async Task Task1()
    {
      await Task.Delay(TimeSpan.FromSeconds(5));
      Debug.WriteLine("Finished Task1");
    }
    public static async Task Task2()
    {
      await Task.Delay(TimeSpan.FromSeconds(10));
      Debug.WriteLine("Finished Task2");
    }
