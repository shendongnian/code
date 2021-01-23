    public class MainViewModel : ViewModelBase
    {
        private readonly KinectSensorChooser _sensorChooser = new KinectSensorChooser();
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            if (IsInDesignMode)
            {
                // do something special, only for design mode
            }
            else
            {
                KinectSensorManager = new KinectSensorManager();
                KinectSensorManager.KinectSensorChanged += OnKinectSensorChanged;
                _sensorChooser.Start();
                if (_sensorChooser.Kinect == null)
                {
                    MessageBox.Show("Unable to detect an available Kinect Sensor");
                    Application.Current.Shutdown();
                }
                // Bind the KinectSensor from the sensorChooser to the KinectSensor on the KinectSensorManager
                var kinectSensorBinding = new Binding("Kinect") { Source = _sensorChooser };
                BindingOperations.SetBinding(this.KinectSensorManager, KinectSensorManager.KinectSensorProperty, kinectSensorBinding);
            }
        }
        #region Kinect Discovery & Setup
        private void OnKinectSensorChanged(object sender, KinectSensorManagerEventArgs<KinectSensor> args)
        {
            if (null != args.OldValue)
                UninitializeKinectServices(args.OldValue);
            if (null != args.NewValue)
                InitializeKinectServices(KinectSensorManager, args.NewValue);
        }
        /// <summary>
        /// Initialize Kinect based services.
        /// </summary>
        /// <param name="kinectSensorManager"></param>
        /// <param name="sensor"></param>
        private void InitializeKinectServices(KinectSensorManager kinectSensorManager, KinectSensor sensor)
        {
            // configure the color stream
            kinectSensorManager.ColorFormat = ColorImageFormat.RgbResolution640x480Fps30;
            kinectSensorManager.ColorStreamEnabled = true;
            // configure the depth stream
            kinectSensorManager.DepthStreamEnabled = true;
            kinectSensorManager.TransformSmoothParameters =
                new TransformSmoothParameters
                {
                    // as the smoothing value is increased responsiveness to the raw data
                    // decreases; therefore, increased smoothing leads to increased latency.
                    Smoothing = 0.5f,
                    // higher value corrects toward the raw data more quickly,
                    // a lower value corrects more slowly and appears smoother.
                    Correction = 0.5f,
                    // number of frames to predict into the future.
                    Prediction = 0.5f,
                    // determines how aggressively to remove jitter from the raw data.
                    JitterRadius = 0.05f,
                    // maximum radius (in meters) that filtered positions can deviate from raw data.
                    MaxDeviationRadius = 0.04f
                };
            // configure the skeleton stream
            sensor.SkeletonFrameReady += OnSkeletonFrameReady;
            kinectSensorManager.SkeletonStreamEnabled = true;
            // initialize the gesture recognizer
            _gestureController = new GestureController();
            _gestureController.GestureRecognized += OnGestureRecognized;
            kinectSensorManager.KinectSensorEnabled = true;
            if (!kinectSensorManager.KinectSensorAppConflict)
            {
                // set up addition Kinect based services here
                // (e.g., SpeechRecognizer)
            }
            kinectSensorManager.ElevationAngle = Settings.Default.KinectAngle;
        }
        /// <summary>
        /// Uninitialize all Kinect services that were initialized in InitializeKinectServices.
        /// </summary>
        /// <param name="sensor"></param>
        private void UninitializeKinectServices(KinectSensor sensor)
        {
            sensor.SkeletonFrameReady -= this.OnSkeletonFrameReady;
        }
        #endregion Kinect Discovery & Setup
        #region Properties
        public KinectSensorManager KinectSensorManager { get; private set; }
        #endregion Properties
    }
