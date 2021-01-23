    public static class VPNCheck
    {
        public static bool IsOn()
        {
            return ((NetworkInterface.GetIsNetworkAvailable())
                    && NetworkInterface.GetAllNetworkInterfaces()
                                       .FirstOrDefault(ni => ni.Description.Contains("Cisco"))?.OperationalStatus == OperationalStatus.Up);
        }
    }
