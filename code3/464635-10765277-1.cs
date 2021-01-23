    private async Task<LoadMoreItemsResult> LoadDataAsync(uint count)
    {
      Task task = Task.Delay( 1 );
      await task;
      for (int i = 0; i < count; i++)
      {
        Add(new MyData { Title = string.Format("Item: {0}, {1}", i, System.DateTime.Now) });
      }
    
      return new LoadMoreItemsResult {Count = count};
    }
