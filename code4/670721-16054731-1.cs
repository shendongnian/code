    Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SmogUser");
    if ((new Guid(key.GetValue("DeviceId", Guid.Empty).ToString()) == Guid.Empty))
    {
        Guid deviceId = Guid.NewGuid();
        key.SetValue("DeviceId", deviceId);
        key.Close();
    }
    else
    {
        Guid deviceId = new Guid(key.GetValue("DeviceId").ToString());
    }
