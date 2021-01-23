    private WriteableBitmap cameraImage;
    private IntPtr cameraBitmapPtr;
    public WriteableBitmap CameraImage
    {
        get { return cameraImage; }
        set
        {
            cameraImage = value;
            cameraBitmapPtr = cameraImage.BackBuffer;
            NotifyPropertyChanged();
        }
    }
