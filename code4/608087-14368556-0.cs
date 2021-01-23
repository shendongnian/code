    using Microsoft.Win32.Registry;
    private static string _deviceId = null;
    public static string DeviceName {
      get {
        if (String.IsNullOrEmpty(_deviceId)) {
          using (RegistryKey key = Registry.LocalMachine.OpenSubKey("Ident", true)) {
            try {
              _deviceId = (string)key.GetValue("Name", "[Unnamed]");
            } catch (Exception e) {
              ErrorWrapper("GetDeviceName", e);
              _deviceId = System.Net.Dns.GetHostName();
            } finally {
              key.Flush();
              key.Close();
            }
          }
        }
        return _deviceId;
      }
    }
