    class Client
    {
      const int Delay = 2000;
      HttpClient m_client = new HttpClient();
      int m_ticks = 0;
      SemaphoreSlim mutex = new SemaphoreSlim(1);
      public async Task<string> Get(string url)
      {
        // Multiple threads could be calling, I need to protect access to m_ticks:
        string result = null;
        await mutex.WaitAsync();
        using (new SemaphoreSlimReleaser(mutex))
        {
            int ticks = Environment.TickCount - m_ticks;
            if (ticks < Delay)
                await Task.Delay(Delay - ticks);
            result = await m_client.GetStringAsync(url);
            m_ticks = Environment.TickCount;
        }
        return result;
      }
    }
