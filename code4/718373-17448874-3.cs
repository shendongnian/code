    public sealed class Device : IDisposable
    {
        private IntPtr _hDevInfo;
        private SP_DEVINFO_DATA _data;
        private Device(IntPtr hDevInfo, SP_DEVINFO_DATA data)
        {
            _hDevInfo = hDevInfo;
            _data = data;
        }
        public static Device Get(string pnpDeviceId)
        {
            if (pnpDeviceId == null)
                throw new ArgumentNullException("pnpDeviceId");
            IntPtr hDevInfo = SetupDiGetClassDevs(IntPtr.Zero, pnpDeviceId, IntPtr.Zero, DIGCF.DIGCF_ALLCLASSES | DIGCF.DIGCF_DEVICEINTERFACE);
            if (hDevInfo == (IntPtr)INVALID_HANDLE_VALUE)
                throw new Win32Exception(Marshal.GetLastWin32Error());
            SP_DEVINFO_DATA data = new SP_DEVINFO_DATA();
            data.cbSize = Marshal.SizeOf(data);
            if (!SetupDiEnumDeviceInfo(hDevInfo, 0, ref data))
            {
                int err = Marshal.GetLastWin32Error();
                if (err == ERROR_NO_MORE_ITEMS)
                    return null;
                throw new Win32Exception(err);
            }
            return new Device(hDevInfo, data) {PnpDeviceId = pnpDeviceId};
        }
        public void Dispose()
        {
            if (_hDevInfo != IntPtr.Zero)
            {
                SetupDiDestroyDeviceInfoList(_hDevInfo);
                _hDevInfo = IntPtr.Zero;
            }
        }
        public string PnpDeviceId { get; private set; }
        public string ParentPnpDeviceId
        {
            get
            {
                return GetStringProperty(DEVPROPKEY.DEVPKEY_Device_Parent);
            }
        }
        public string[] ChildrenPnpDeviceIds
        {
            get
            {
                return GetStringListProperty(DEVPROPKEY.DEVPKEY_Device_Children);
            }
        }
        private string[] GetStringListProperty(DEVPROPKEY key)
        {
            int type;
            int size;
            SetupDiGetDeviceProperty(_hDevInfo, ref _data, ref key, out type, IntPtr.Zero, 0, out size, 0);
            if (size == 0)
                return new string[0];
            IntPtr buffer = Marshal.AllocHGlobal(size);
            try
            {
                if (!SetupDiGetDeviceProperty(_hDevInfo, ref _data, ref key, out type, buffer, size, out size, 0))
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                List<string> strings = new List<string>();
                IntPtr current = buffer;
                do
                {
                    string s = Marshal.PtrToStringUni(current);
                    if (string.IsNullOrEmpty(s))
                        break;
                    strings.Add(s);
                    current += (1 + s.Length) * 2;
                }
                while (true);
                return strings.ToArray();
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }
        private string GetStringProperty(DEVPROPKEY key)
        {
            int type;
            int size;
            SetupDiGetDeviceProperty(_hDevInfo, ref _data, ref key, out type, IntPtr.Zero, 0, out size, 0);
            if (size == 0)
                return null;
            IntPtr buffer = Marshal.AllocHGlobal(size);
            try
            {
                if (!SetupDiGetDeviceProperty(_hDevInfo, ref _data, ref key, out type, buffer, size, out size, 0))
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                return Marshal.PtrToStringUni(buffer);
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }
        private const int INVALID_HANDLE_VALUE = -1;
        private const int ERROR_NO_MORE_ITEMS = 259;
        [StructLayout(LayoutKind.Sequential)]
        private struct SP_DEVINFO_DATA
        {
            public int cbSize;
            public Guid ClassGuid;
            public uint DevInst;
            public IntPtr Reserved;
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct DEVPROPKEY
        {
            public Guid fmtid;
            public uint pid;
            // from devpkey.h
            public static readonly DEVPROPKEY DEVPKEY_Device_Parent = new DEVPROPKEY { fmtid = new Guid("{4340A6C5-93FA-4706-972C-7B648008A5A7}"), pid = 8 };
            public static readonly DEVPROPKEY DEVPKEY_Device_Children = new DEVPROPKEY { fmtid = new Guid("{4340A6C5-93FA-4706-972C-7B648008A5A7}"), pid = 9 };
        }
        [Flags]
        private enum DIGCF : uint
        {
            DIGCF_DEFAULT = 0x00000001,
            DIGCF_PRESENT = 0x00000002,
            DIGCF_ALLCLASSES = 0x00000004,
            DIGCF_PROFILE = 0x00000008,
            DIGCF_DEVICEINTERFACE = 0x00000010,
        }
        [DllImport("setupapi.dll", SetLastError = true)]
        private static extern bool SetupDiEnumDeviceInfo(IntPtr DeviceInfoSet, uint MemberIndex, ref SP_DEVINFO_DATA DeviceInfoData);
        [DllImport("setupapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern IntPtr SetupDiGetClassDevs(IntPtr ClassGuid, string Enumerator, IntPtr hwndParent, DIGCF Flags);
        // vista required
        [DllImport("setupapi.dll", SetLastError = true, EntryPoint = "SetupDiGetDevicePropertyW")]
        private static extern bool SetupDiGetDeviceProperty(IntPtr DeviceInfoSet, ref SP_DEVINFO_DATA DeviceInfoData, ref DEVPROPKEY propertyKey, out int propertyType, IntPtr propertyBuffer, int propertyBufferSize, out int requiredSize, int flags);
        [DllImport("setupapi.dll", CharSet = CharSet.Unicode)]
        private static extern bool SetupDiDestroyDeviceInfoList(IntPtr DeviceInfoSet);
    }
