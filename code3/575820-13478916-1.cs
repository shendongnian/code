    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Shapes;
    using Microsoft.Phone.Controls;
    using Microsoft.Devices;
    using System.IO;
    using System.IO.IsolatedStorage;
    using Microsoft.Xna.Framework.Media;
    using Microsoft.Devices.Sensors;
    
    namespace PhoneApp1
    {
        public partial class MainPage : PhoneApplicationPage
        {
            private Accelerometer AccelerometerSensor;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            AccelerometerSensor = new Accelerometer();
            AccelerometerSensor.CurrentValueChanged += new EventHandler<SensorReadingEventArgs<AccelerometerReading>>(AccelerometerSensor_ReadingChanged);
            AccelerometerStartup();
            if ((PhotoCamera.IsCameraTypeSupported(CameraType.Primary) == true))
            {
                viewfinderCanvas.Visibility = Visibility.Visible;
                var cam = new Microsoft.Devices.PhotoCamera(CameraType.Primary);
                if (Orientation == PageOrientation.PortraitUp || Orientation == PageOrientation.PortraitDown || Orientation == PageOrientation.Portrait)
                {
                    // Rotate for LandscapeRight orientation.
                    viewfinderBrush.RelativeTransform =
                        new CompositeTransform() { CenterX = 0.5, CenterY = 0.5, Rotation = 90 };
                }
                viewfinderBrush.SetSource(cam);
            }
        }
        #region Accelerometer Readging Changes Functions
        public void AccelerometerSensor_ReadingChanged(object sender, SensorReadingEventArgs<AccelerometerReading> e)
        {
               
        }
        #endregion
        #region Accelerometer Startup Function
        private void AccelerometerStartup()
        {
            try
            {
                if (AccelerometerSensor != null)
                {
                    AccelerometerSensor.Start();
                    
                }
            }
            catch (AccelerometerFailedException)
            {
            }
            catch (UnauthorizedAccessException)
            {
            }
        }
        #endregion
    }
}
