    private static Lazy<string> _hardwareId = new Lazy<string>(() => BitConverter.ToString(Windows.System.Profile.HardwareIdentification.GetPackageSpecificToken(null).Id.ToArray()), true);
    
    public string HardwareId()   
    { 
         return _hardwareId.Value;
    }
