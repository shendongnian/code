    public bool CheckForVPNInterface()
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                NetworkInterface[] interfaces = 
    NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface Interface in interfaces)
                {
                    // This is the OpenVPN driver for windows. 
                    if (Interface.Description.Contains("TAP-Windows Adapter")
                      && Interface.OperationalStatus == OperationalStatus.Up)
                    {
                            return true;
                    }
                }
            }
            return false;
        }
