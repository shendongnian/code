    #region Constants
    public const string IsolatedStoragePath = "Pictures";
    #endregion
    #region Properties
    public ObservableCollection<Picture> Pictures
    {
        get; private set;
    }
    #endregion
    #region Singleton Pattern
    private PictureRepository()
    {
        LoadAllPicturesFromIsolatedStorage();
    }
    public static readonly PictureRepository Instance = new PictureRepository();
    #endregion
    /// <summary>        
    /// Saves to local storage
    /// This method gets two parameters: the captured picture instance and the name of the pictures folder in the isolated storage
    /// </summary>
    /// <param name="capturedPicture"></param>
    /// <param name="directory"></param>
    public void SaveToLocalStorage(CapturedPicture capturedPicture, string directory)
    {
        //call IsolatedStorageFile.GetUserStoreForApplication to get an isolated storage file
        var isoFile = IsolatedStorageFile.GetUserStoreForApplication();
        //Call the IsolatedStorageFile.EnsureDirectory extension method located in the Common IsolatedStorageFileExtensions class to confirm that the pictures folder exists.
        isoFile.EnsureDirectory(directory);
        //Combine the pictures folder and captured picture file name and use this path to create a new file 
        string filePath = Path.Combine(directory, capturedPicture.FileName);
        using (var fileStream = isoFile.CreateFile(filePath))
        {
            using (var writer = new BinaryWriter(fileStream))
            {
                capturedPicture.Serialize(writer);
            }
        }
    }
    /// <summary>
    /// To load all saved pictures and add them to the pictures list page
    /// </summary>
    public CapturedPicture LoadFromLocalStorage(string fileName, string directory)
    {
        //To open the file, add a call to the IsolatedStorageFile.GetUserStoreForApplication
        var isoFile = IsolatedStorageFile.GetUserStoreForApplication();
        //Combine the directory and file name
        string filePath = Path.Combine(directory, fileName);
        //use the path to open the picture file from the isolated storage by using the IsolatedStorageFile.OpenFile method
        using (var fileStream = isoFile.OpenFile(filePath, FileMode.Open, FileAccess.Read))
        {
            //create a BinaryReader instance for deserializing the CapturedPicture instance
            using (var reader = new BinaryReader(fileStream))
            {
                var capturedPicture = new CapturedPicture();
                //create a new instance of the type CapturedPicture called CapturedPicture.Deserialize to deserialize the captured picture and return it
                capturedPicture.Deserialize(reader);
                return capturedPicture;
            }
        }
    }
    /// <summary>
    /// To load all the pictures at start time
    /// </summary>
    private void LoadAllPicturesFromIsolatedStorage()
    {
        //add call to the IsolatedStorageFile.GetUserStoreForApplication to open an isolated storage file
        var isoFile = IsolatedStorageFile.GetUserStoreForApplication();
        //Call the IsolatedStorageFile.EnsureDirectory extension method located in the Common IsolatedStorageFileExtensions class to confirm that the pictures folder exists
        isoFile.EnsureDirectory(IsolatedStoragePath);
        //Call the IsolatedStorageFile.GetFileNames using the pictures directory and *.jpg as a filter to get all saved pictures
        var pictureFiles = isoFile.GetFileNames(Path.Combine(IsolatedStoragePath, "*.jpg"));
        //var pictureFiles = isoFile.GetFileNames(Path.Combine(IsolatedStoragePath, ""));
		var pictures = new List<Picture>();
		
        //Iterate through all the picture files in the list and load each using the LoadFromLocalStorage you created earlier
        foreach (var pictureFile in pictureFiles)
        {
            var picture = LoadFromLocalStorage(pictureFile, IsolatedStoragePath);
            pictures.Add(picture);
        }
		
		Pictures = new ObservableCollection<Picture>(pictures.OrderBy(x => x.DateTaken));
    }
