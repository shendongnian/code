    // (in your page/window constructor):
    
    this.KinectDevice = KinectSensor.KinectSensors
    .FirstOrDefault(x => x.Status == KinectStatus.Connected);
    
    // (and create a property like this:)
    
    public KinectSensor KinectDevice
    {
    get { return this._KinectDevice; }
    set
    {
    if (this._KinectDevice != value)
    {
    //Uninitialize
    if (this._KinectDevice != null)
    {
    this._KinectDevice.Stop();
    this._KinectDevice.SkeletonFrameReady -= KinectDevice_SkeletonFrameReady;
    this._KinectDevice.SkeletonStream.Disable();
    this._FrameSkeletons = null;
    }
    
    this._KinectDevice = value;
    
    //Initialize
    if (this._KinectDevice != null)
    {
    if (this._KinectDevice.Status == KinectStatus.Connected)
    {
    this._KinectDevice.SkeletonStream.Enable();
    this._FrameSkeletons = new
    Skeleton[this._KinectDevice.SkeletonStream.FrameSkeletonArrayLength];
    this.KinectDevice.SkeletonFrameReady +=
    KinectDevice_SkeletonFrameReady;
    ColorImageStream colorStream = this._KinectDevice.ColorStream;
    colorStream.Enable();
    this._ColorImageBitmap = new WriteableBitmap(colorStream.FrameWidth,
    colorStream.FrameHeight, 96, 96, PixelFormats.Bgr32, null);
    this._ColorImageBitmapRect = new Int32Rect(0, 0, colorStream.FrameWidth,
    colorStream.FrameHeight);
    this._ColorImageStride = colorStream.FrameWidth * colorStream.FrameBytesPerPixel;
    ColorImageElement.Source = this._ColorImageBitmap;
    this._KinectDevice.ColorFrameReady += Kinect_ColorFrameReady;
    
    this.ColorImageElement.Dispatcher.BeginInvoke(new Action(() =>
    {
    this._ColorImageBitmap = new WriteableBitmap(colorStream.FrameWidth,
    colorStream.FrameHeight,
    96, 96, PixelFormats.Bgr32,
    null);
    this._ColorImageBitmapRect = new Int32Rect(0, 0, colorStream.FrameWidth,
    colorStream.FrameHeight);
    this._ColorImageStride = colorStream.FrameWidth *
    colorStream.FrameBytesPerPixel;
    this._ColorImagePixelData = new byte[colorStream.FramePixelDataLength];
    
    this.ColorImageElement.Source = this._ColorImageBitmap;
    }));
    this._KinectDevice.Start();
    }
    }
    }
    }
    }
