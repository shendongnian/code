    public class EquipmentObj
    {
        public EquipmentObj(string deviceType)
        {
            this.DeviceType = EquipmentObjManager.GetDeviceType(deviceType);
        }
        public string DeviceType { get; set; }
    }
    public class EquipmentObjManager
    {
        private static Dictionary<string, string> EquipmentList = new Dictionary<string, string>();
        public static string GetDeviceType(string deviceType)
        {
            return EquipmentList.ContainsKey(deviceType) ? EquipmentList[deviceType] : "Default";
        }
        public static void AddDeviceType(string deviceTypeKey, string deviceType)
        {
            if (!EquipmentList.ContainsKey(deviceTypeKey))
            {
                EquipmentList.Add(deviceTypeKey, deviceType);
            }
        }
    }
