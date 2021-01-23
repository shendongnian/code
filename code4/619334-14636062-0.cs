    class EquipmentObj
    {
        public EquipmentObj(string deviceType)
        {
            addItems(); 
            this.DeviceType = EquipmentList.ContainsKey(device_Type) ? EquipmentList[deviceType] : "Default";
        }
        public string DeviceType { get; set; }
        private static Dictionary<string, string> EquipmentList = new Dictionary<string, string>();
        public static void addItems()
        {
            //Add items to Dictionary 
        }
    }
