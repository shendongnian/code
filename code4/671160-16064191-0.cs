    private static async Task<DateTime> CountToAsync(int num = 10)
    {
      for (int i = 0; i < num; i++)
      {
        await Task.Delay(TimeSpan.FromSeconds(1));
      }
      return DateTime.Now;
    }
