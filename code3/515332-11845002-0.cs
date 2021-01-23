    public void kinectInit()
    {
        KinectSensor.KinectSensors.StatusChanged += (object sender, StatusChangedEventArgs e) =>
        {
            if (e.Sensor == kinectSensor)
            {
                if (e.Status != KinectStatus.Connected)
                {
                    SetSensor(null);
                }
            }else if ((kinectSensor == null) && (e.Status == KinectStatus.Connected))
            {
                SetSensor(e.Sensor);
            }
        };
    
        foreach (var sensor in KinectSensor.KinectSensors)
        {
            if (sensor.Status == KinectStatus.Connected)
            {
                SetSensor(sensor);
             }
        }
    }
