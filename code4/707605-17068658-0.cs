    void Write()
    {
        FileIO.AppendTextAsync(
            file, DateTime.Now + " testing!"+Environment.NewLine).Wait();
    }
    
    void Create()
    {
        file = ApplicationData.Current.LocalFolder.CreateFileAsync(
            "test.txt", CreationCollisionOptions.OpenIfExists).Result;
    }
