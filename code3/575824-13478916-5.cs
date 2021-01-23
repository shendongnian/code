    using System;
    using System.Windows;
    using Microsoft.Phone.Controls;
    using Microsoft.Devices;
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
                AccelerometerStartup();
    
                if ((PhotoCamera.IsCameraTypeSupported(CameraType.Primary) == true))
                {
                    viewfinderCanvas.Visibility = Visibility.Visible;
                    var cam = new Microsoft.Devices.PhotoCamera(CameraType.Primary);
    
                    viewfinderBrush.SetSource(cam);
                }
            }
    
    
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
