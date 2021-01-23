    void OnUSBDetectedOrDetached(object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject _o = e.NewEvent["TargetInstance"] as ManagementBaseObject;
            if (_o != null)
            {
                using (ManagementObject mo = new ManagementObject(_o["Dependent"].ToString()))
                {
                    if (mo != null)
                    {
                        try
                        {
                            string devId = string.Empty;
                            devId = mo.GetPropertyValue("DeviceID").ToString();
                            if (devId != string.Empty)
                            {
                                Trace.WriteLine("Detected USB Device, DevId: " + devId);
                            }
    ....
