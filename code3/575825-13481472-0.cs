    private PhotoCamera cam;
    public MainPage()
    {
        InitializeComponent();
        AccelerometerSensor = new Accelerometer();
        AccelerometerSensor.CurrentValueChanged += new EventHandler<SensorReadingEventArgs<AccelerometerReading>>(AccelerometerSensor_CurrentValueChanged);
        AccelerometerStartup();
        if (PhotoCamera.IsCameraTypeSupported(CameraType.Primary))
        {
            viewfinderCanvas.Visibility = Visibility.Visible;
            cam = new PhotoCamera(CameraType.Primary);
            viewfinderBrush.SetSource(cam);
        }
    }
