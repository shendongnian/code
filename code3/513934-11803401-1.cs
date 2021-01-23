    protected async Task<bool> CannotChangeSignature()
    {
      ...
      try
      {
        await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
        return true;
      }
      catch(FileNotFoundException)
      {
        return false;
      }
    }
