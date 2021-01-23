        public void Gesture_Detected(Object sender, SwipeEventArgs e)
        {
            Debug.WriteLine("Number of touches: " + e.NumberOfTouches + " Direction: " + e.Direction);
        }
        public MainPage()
        {
            this.InitializeComponent();
            SwipeGestureDetector gestureDetector = new SwipeGestureDetector(this.rootGrid);
            gestureDetector.SwipeDetected += Gesture_Detected;
