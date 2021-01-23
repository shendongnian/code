    Computer myComputer = new Computer();
    
    //myComputer.
    myComputer.Open();
    
    myComputer.GPUEnabled = true; //This is the line you are missing.
    
    foreach (var hardwareItem in myComputer.Hardware)
    {
    
        if (hardwareItem.HardwareType == HardwareType.GpuNvidia)
        {
            foreach (var sensor in hardwareItem.Sensors)
            {
                if (sensor.SensorType == SensorType.Temperature)
                {
                    MessageBox.Show(String.Format("The current temperature is {0}", sensor.Value));
                }
            }
        }
    
    }
