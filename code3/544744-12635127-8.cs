    public class ModelClass
    {
        public string I2CDevName { get; set; }
        public string I2CDeviceAddress { get; set; }
        public ModelClass(string DeviceName, string DeviceAddress)
        {
            this.I2CDevName = DeviceName;
            this.I2CDeviceAddress = DeviceAddress;
        }
    }
