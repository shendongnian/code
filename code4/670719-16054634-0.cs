            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SmogUser");
            if (key != null)
            {
                var value = key.GetValue("DeviceId", null) ?? Guid.Empty;
                if (Guid.Empty.Equals(value))
                {
                    Guid deviceId = Guid.NewGuid();
                    key.SetValue("DeviceId", deviceId);
                    key.Close();
                }
                else
                {
                    var deviceId = (Guid)key.GetValue("DeviceId");
                }
            }
