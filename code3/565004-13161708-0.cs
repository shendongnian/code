    public static class ObservableFile2
    {
      public static IObservable<string> Create(string fileName)
      {
        return Observable.Create<string>(async (subject, token) =>
        {
          try
          {
            using (var streamReader = new StreamReader(new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
              while (true)
              {
                token.ThrowIfCancellationRequested();
                var line = await streamReader.ReadLineAsync();
                if (line == null)
                {
                  subject.OnCompleted();
                  return;
                }
                subject.OnNext(line);
              }
            }
          }
          catch (Exception ex)
          {
            subject.OnError(ex);
          }
        });
      }
    }
