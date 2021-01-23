    void Kinect_StatusChanged(object sender, StatusChangedEventArgs e)
    {
        switch (e.Status)
        {
            case KinectStatus.Connected:
                if (kinectSensor == null)
                {
                    kinectSensor = e.Sensor;
                    Initialize();
                }
                break;
            case KinectStatus.Disconnected:
                if (kinectSensor == e.Sensor)
                {
                    Clean();
                    // Notify user, change state of APP appropriately
                }
                break;
            case KinectStatus.NotReady:
                break;
            case KinectStatus.NotPowered:
                if (kinectSensor == e.Sensor)
                {
                    Clean();
                    // Notify user, change state of APP appropriately
                }
                break;
            default:
                // Throw exception, notify user or ignore depending on use case
                break;
        }
    }
