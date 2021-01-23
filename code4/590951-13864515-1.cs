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
                _sensorChooser.Start();
                if (_sensorChooser.Kinect == null)
                {
                    MessageBox.Show("Unable to detect an available Kinect Sensor");
                    Application.Current.Shutdown();
                }
            }
        }
