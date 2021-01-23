    public async Task WriteLineFuncAsync(string str)
    {
      await Task.Delay(2000);
      Console.WriteLine(str);
    }
    public void WriteLineFunc(string str)
    {
      Thread.Sleep(2000);
      Console.WriteLine(str);
    }
