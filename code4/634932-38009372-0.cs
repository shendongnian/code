    try
    {
      var t = new Task(() => Work(cancelSource.Token));
      t.Start();
    }
    if (t.IsCancelled)
      Console.WriteLine("Canceled!");
    }
