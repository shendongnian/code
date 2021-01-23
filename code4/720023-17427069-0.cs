    public CameraControlViewModel( DataModel dataModel )
    : base( dataModel )
    {
        dataModel.PropertyChanged += DataModelOnPropertyChanged;    
        _captureImageCommand = new RelayCommand( captureImage, captureImage_CanExecute );
        _capturedImage = new BitmapImage();
        _capturedImage.BeginInit();
        _capturedImage.UriSource = new Uri( "Images/fingerprint.jpg", UriKind.Relative );
        _capturedImage.CacheOption = BitmapCacheOption.OnLoad;
        _capturedImage.EndInit();
    }
    private bool captureImage_CanExecute( object arg)
    {
        return !dataModel.IsScriptRunning && !_captureInProgress;
    }
