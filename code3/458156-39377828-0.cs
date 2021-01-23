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
                return key.GetSubKeyNames().Select(key.OpenSubKey);
            }
            public static IEnumerable<UsbSerialPort> GetPorts()
            {
                var existingPorts = SerialPort.GetPortNames();
                var enumUsbKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Enum\USB");
                if (enumUsbKey == null)
                    throw new ArgumentNullException("USB", "No enumerable USB devices found in registry");
                foreach (var devBaseKey in GetSubKeys(enumUsbKey))
                {
                    foreach (var devFnKey in GetSubKeys(devBaseKey))
                    {
                        string friendlyName =
                            (string) devFnKey.GetValue("FriendlyName") ??
                            (string) devFnKey.GetValue("DeviceDesc");
                        var devParamsKey = devFnKey.OpenSubKey("Device Parameters");
                        string portName = (string) devParamsKey?.GetValue("PortName");
                        if (!string.IsNullOrEmpty(portName) &&
                            existingPorts.Contains(portName))
                            yield return new UsbSerialPort(portName, devBaseKey.Name + @"\" + devFnKey.Name, friendlyName);
                    }
                }
            }
            public override string ToString()
            {
                return string.Format("{0} Friendly: {1} DeviceId: {2}", PortName, FriendlyName, DeviceId);
            }
        }
