    public async Task AsyncSearchAll(SearchPanelViewModel searchPanelViewModel, SearchSettings searchSettings, CancellationToken cancellationToken)
    {
      while (..)
      {
        var results = await Task.Run(() => /* search more */);
        /* update panel with results */
      }
    }
