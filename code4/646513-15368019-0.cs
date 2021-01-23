    private SemaphoreSlim semaphore = new SemaphoreSlim(1);
    private async void LoadLinkPreview()
    {
        try
        {
            await semaphore.WaitAsync();
            Debug.WriteLine(DateTime.Now + ": Entered LinkPreview");
            await Task.Delay(2000);//placeholder for real work/IO
        }
        finally
        {
            Debug.WriteLine(DateTime.Now + ": Left LinkPreview");
            semaphore.Release();
        }
    }
