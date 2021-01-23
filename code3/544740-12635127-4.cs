    public class ModelClass
    {
        public string I2CDevName { get; set; }
        public string I2CDeviceAddress { get; set; }
        public ModelClass(string DeviceName, string DeviceAddress)
        {
            this.I2CDevName = DeviceName;
            this.I2CDeviceAddress = DeviceAddress;
        }
        //Collection Factory
        public static ObservableCollection<ModelClass> CreateCollection(List<string[]> models)
        {
            ObservableCollection<ModelClass> tmpColl = new ObservableCollection<ModelClass>();
            foreach (string[] s in models)
            {
                tmpColl.Add(new ModelClass(s[0],s[1]));
            }
            return tmpColl;
        }
    }
