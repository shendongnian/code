    public async void PushButton()
    {
      Progress<MyUpdateType> progress = new Progress<MyUpdateType>(update =>
      {
        /* update panel */
      });
      await Task.Run(() => SearchAll(..., progress));
    }
    public void SearchAll(SearchPanelViewModel searchPanelViewModel,
        SearchSettings searchSettings, CancellationToken cancellationToken,
        IProgress<MyUpdateType> progress)
    {
      while (..)
      {
        /* search more */
        if (progress != null)
          progress.Report(new MyUpdateType(...));
      }
    }
