    private ObservableCollection<CameraInfo> _listCamera; 
    public ObservableCollection<CameraInfo> ListCameras
    {
        get { return _listCamera ?? (_listCamera = new ObservableCollection<CameraInfo>()); }
    }
