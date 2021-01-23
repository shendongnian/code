    public static void start()
            {
                KinectSensor.KinectSensors.StatusChanged += kinectSensorsStatusChanged;
                DiscoverSensor();
            }
    
    
     private static void kinectSensorsStatusChanged(object sender, StatusChangedEventArgs e)
            {
    
                KinectSensor oldSensor = Kinect;
                if (oldSensor != null)
                {
                    UninitializeKinect();
                }
                var status = e.Status;
                if (Kinect == null)
                {
                    //updateStatus(status);
                    if (e.Status == KinectStatus.Connected)
                    {
    
                        Kinect = e.Sensor;
                        DiscoverSensor();
                    }
                }
                else
                {
                    if (Kinect == e.Sensor)
                    {
                        //updateStatus(status);
                        if (e.Status == KinectStatus.Disconnected ||
                            e.Status == KinectStatus.NotPowered)
                        {
                            Kinect = null;
                            sensorConflict = false;
                            DiscoverSensor();
                        }
                    }
                }
    
            }
    
    private static DispatcherTimer readyTimer;
    
    private static void UninitializeKinect()
            {
                if (speechRecognizer != null && Kinect != null)
                {
                    Kinect.AudioSource.Stop();
                    Kinect.SkeletonFrameReady -= kinect_SkeletonFrameReady;
                    Kinect.SkeletonStream.Disable();
                    Kinect.Stop();
                    //this.FrameSkeletons = null;
                    speechRecognizer.RecognizeAsyncCancel();
                    speechRecognizer.RecognizeAsyncStop();
                }
    
                if (readyTimer != null)
                {
                    readyTimer.Stop();
                    readyTimer = null;
                }
            }
