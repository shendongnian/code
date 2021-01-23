        public string detectArduinoPort()
        {
            ManagementScope mScope = new ManagementScope();
            SelectQuery query = new SelectQuery("SELECT * FROM Win32_SerialPort");
            ManagementObjectSearcher objectList = new ManagementObjectSearcher(mScope, query);
            try
            {
                foreach (ManagementObject obj in objectList.Get())
                {
                    string description = obj["Description"].ToString();
                    string deviceId = obj["DeviceID"].ToString();
                    if (description.Contains("uino"))
                    {
                        return deviceId;
                    }
                }
            }
            catch (Exception)
            {
            }
            return "";
        }
