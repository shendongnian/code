    private static async Task SaveAsync(string imageUrl, Stream resultStream)
    {
      bool success = false;
      try
      {
        await Config.StorageCacheImpl.SaveAsync(imageUrl, downloadResult.ResultStream);
      }
      finally
      {
        if (!success)
          Log("[error] failed to save in storage: " + imageUri);
      }
    }
