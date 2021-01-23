    private void DeleteSynchronous(string path)
    {
        StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
        Task t = localFolder.DeleteAsync(StorageDeleteOption.PermanentDelete).AsTask();
        t.Wait();
    }
    private void FunctionThatNeedsToBeSynchronous()
    {
        // Do some work here
        // ....
        // Delete something in storage synchronously
        DeleteSynchronous("pathGoesHere");
        // Do other work here 
        // .....
    }
