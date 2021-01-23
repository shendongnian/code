    public async Task ProcessaA()
    {
      for (int i = 0; i <= 100; i++)
      {
        pbProcessoA.Value = i;
        await Task.Run(() => { Thread.Sleep(500); });
      }
    }
