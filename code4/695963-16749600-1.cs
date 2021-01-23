    Task DoSyncAsync()
    {
      Progress<MyProgressType> progress = new Progress<MyProgressType>(progressUpdate =>
      {
        myDataBoundUIProperty = progressUpdate;
      });
      return Task.Run(() => DoSync(progress));
    }
    void DoSync(IProgress<MyProgressType> progress)
    {
      ...
      if (progress != null)
        progress.Report(new MyProgressType(...));
      ...
    }
