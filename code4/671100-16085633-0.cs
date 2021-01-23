    private static string getName() {
      string name = null;
      using (RegistryKey key = Registry.LocalMachine.OpenSubKey("Ident", true)) {
        var name = key.GetValue("Name", [Unnamed]) as string;
      }
      if (String.IsNullOrEmpty(name)) {
        name = getDeviceID();
      }
      return name;
    }
