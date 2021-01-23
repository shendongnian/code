    protected override void OnStart(string args[])
    {
        // your other initialization code goes here
        // savePhotos is of type System.Threading.Thread
        savePhotosThread = new Thread(new ThreadStart(SavePhotos));
        savePhotosThread.IsBackground = true;
        savePhotosThread.Name = "Save Photos Thread";
        savePhotosThread.Start();
    }
    You'll place the functionality for saving the files in the `SavePhotos` method, maybe something like this:
    private void SavePhotos()
    {
 
        // logic to save photos
    }
