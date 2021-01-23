        using System.IO.Ports;
        using System.Linq;
        using Microsoft.Win32;
        public class UsbSerialPort
        {
            public readonly string PortName;
            public readonly string DeviceId;
            public readonly string FriendlyName;
            private UsbSerialPort(string name, string id, string friendly)
            {
                PortName = name;
                DeviceId = id;
                FriendlyName = friendly;
            }
            private static IEnumerable<RegistryKey> GetSubKeys(RegistryKey key)
            {
                foreach (string keyName in key.GetSubKeyNames())
                    using (var subKey = key.OpenSubKey(keyName))
                        yield return subKey;
            }
            private static string GetName(RegistryKey key)
            {
                string name = key.Name;
                int idx;
                return (idx = name.LastIndexOf('\\')) == -1 ?
                    name : name.Substring(idx + 1);
            }
            public static IEnumerable<UsbSerialPort> GetPorts()
            {
                var existingPorts = SerialPort.GetPortNames();
                using (var enumUsbKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Enum\USB"))
                {
                    if (enumUsbKey == null)
                        throw new ArgumentNullException("USB", "No enumerable USB devices found in registry");
                    foreach (var devBaseKey in GetSubKeys(enumUsbKey))
                    {
                        foreach (var devFnKey in GetSubKeys(devBaseKey))
                        {
                            string friendlyName =
                                (string) devFnKey.GetValue("FriendlyName") ??
                                (string) devFnKey.GetValue("DeviceDesc");
                            using (var devParamsKey = devFnKey.OpenSubKey("Device Parameters"))
                            {
                                string portName = (string) devParamsKey?.GetValue("PortName");
                                if (!string.IsNullOrEmpty(portName) &&
                                    existingPorts.Contains(portName))
                                    yield return new UsbSerialPort(portName, GetName(devBaseKey) + @"\" + GetName(devFnKey), friendlyName);
                            }
                        }
    
                    }
                }
            }
            public override string ToString()
            {
                return string.Format("{0} Friendly: {1} DeviceId: {2}", PortName, FriendlyName, DeviceId);
            }
        }
