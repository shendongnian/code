    // represents a device with it's settings
    public class Device
    {
       public string Type { get; set;}
    
       public List<Setting> Settings { get; set; }
    }
    
    // represents a setting, agnostic of which device it applies to
    public class Setting
    {
       public string Setting { get; set; }
    
       public string Value { get; set; }
    }
    
    // represents mapping which devices has which settings
    public class DeviceSettings
    {
       public List<string> ApplicableDevices { get; set; }
    
       public List<Settings> ApplicableSettings { get; set; }
    }
