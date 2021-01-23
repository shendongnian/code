    try
    {
      Task.Run(() => Work(cancelSource.Token), cancelSource.Token);
    }
    if (t.IsCancelled)
      Console.WriteLine("Canceled!");
    }
