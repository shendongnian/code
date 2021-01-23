    void OnUserAction() {
      GetCurrencyCode().ContinueWith(GetCurrencyCodeCallback);
    }
    void GetCurrencyCodeCallback(Task<String> task) {
      if (!task.IsFaulted)
        Console.WriteLine(task.Result);
      else
        Console.WriteLine(task.Exception);
    }
