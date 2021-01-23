    class clsGetInputID {
        private const int RID_INPUT = 0x10000003;
        private const int RIDEV_INPUTSINK = 0x00000100;
        [DllImport("user32.dll", SetLastError = true)]
        extern static uint GetRawInputDeviceInfo(IntPtr hDevice, uint uiCommand, IntPtr pData, ref uint pcbSize);
        [DllImport("User32.dll")]
        extern static uint GetRawInputData(IntPtr hRawInput, uint uiCommand, IntPtr pData, ref uint pcbSize, uint cbSizeHeader);
        [DllImport("User32.dll")]
        extern static bool RegisterRawInputDevices(RAWINPUTDEVICE[] pRawInputDevice, uint uiNumDevices, uint cbSize);
        
        [Flags()]
        public enum RawMouseFlags : ushort {
            /// <summary>Relative to the last position.</summary>
            MoveRelative = 0,
            /// <summary>Absolute positioning.</summary>
            MoveAbsolute = 1,
            /// <summary>Coordinate data is mapped to a virtual desktop.</summary>
            VirtualDesktop = 2,
            /// <summary>Attributes for the mouse have changed.</summary>
            AttributesChanged = 4
        }
        [Flags()]
        public enum RawMouseButtons : ushort {
            /// <summary>No button.</summary>
            None = 0,
            /// <summary>Left (button 1) down.</summary>
            LeftDown = 0x0001,
            /// <summary>Left (button 1) up.</summary>
            LeftUp = 0x0002,
            /// <summary>Right (button 2) down.</summary>
            RightDown = 0x0004,
            /// <summary>Right (button 2) up.</summary>
            RightUp = 0x0008,
            /// <summary>Middle (button 3) down.</summary>
            MiddleDown = 0x0010,
            /// <summary>Middle (button 3) up.</summary>
            MiddleUp = 0x0020,
            /// <summary>Button 4 down.</summary>
            Button4Down = 0x0040,
            /// <summary>Button 4 up.</summary>
            Button4Up = 0x0080,
            /// <summary>Button 5 down.</summary>
            Button5Down = 0x0100,
            /// <summary>Button 5 up.</summary>
            Button5Up = 0x0200,
            /// <summary>Mouse wheel moved.</summary>
            MouseWheel = 0x0400
        }
        [StructLayout(LayoutKind.Sequential)]
        internal struct RAWINPUTDEVICE {
            [MarshalAs(UnmanagedType.U2)]
            public ushort usUsagePage;
            [MarshalAs(UnmanagedType.U2)]
            public ushort usUsage;
            [MarshalAs(UnmanagedType.U4)]
            public int dwFlags;
            public IntPtr hwndTarget;
        }
        [StructLayout(LayoutKind.Sequential)]
        internal struct RAWHID {
            [MarshalAs(UnmanagedType.U4)]
            public int dwSizHid;
            [MarshalAs(UnmanagedType.U4)]
            public int dwCount;
        }
        [StructLayout(LayoutKind.Explicit)]
        public struct RawMouse {
            /// <summary>
            /// The mouse state.
            /// </summary>
            [FieldOffset(0)]
            public RawMouseFlags Flags;
            /// <summary>
            /// Flags for the event.
            /// </summary>
            [FieldOffset(4)]
            public RawMouseButtons ButtonFlags;
            /// <summary>
            /// If the mouse wheel is moved, this will contain the delta amount.
            /// </summary>
            [FieldOffset(6)]
            public ushort ButtonData;
            /// <summary>
            /// Raw button data.
            /// </summary>
            [FieldOffset(8)]
            public uint RawButtons;
            /// <summary>
            /// The motion in the X direction. This is signed relative motion or 
            /// absolute motion, depending on the value of usFlags. 
            /// </summary>
            [FieldOffset(12)]
            public int LastX;
            /// <summary>
            /// The motion in the Y direction. This is signed relative motion or absolute motion, 
            /// depending on the value of usFlags. 
            /// </summary>
            [FieldOffset(16)]
            public int LastY;
            /// <summary>
            /// The device-specific additional information for the event. 
            /// </summary>
            [FieldOffset(20)]
            public uint ExtraInformation;
        }
        [StructLayout(LayoutKind.Sequential)]
        internal struct RAWKEYBOARD {
            [MarshalAs(UnmanagedType.U2)]
            public ushort MakeCode;
            [MarshalAs(UnmanagedType.U2)]
            public ushort Flags;
            [MarshalAs(UnmanagedType.U2)]
            public ushort Reserved;
            [MarshalAs(UnmanagedType.U2)]
            public ushort VKey;
            [MarshalAs(UnmanagedType.U4)]
            public uint Message;
            [MarshalAs(UnmanagedType.U4)]
            public uint ExtraInformation;
        }
        public enum RawInputType {
            /// <summary>
            /// Mouse input.
            /// </summary>
            Mouse = 0,
            /// <summary>
            /// Keyboard input.
            /// </summary>
            Keyboard = 1,
            /// <summary>
            /// Another device that is not the keyboard or the mouse.
            /// </summary>
            HID = 2
        }
        [StructLayout(LayoutKind.Explicit)]
        internal struct RawInput {
            /// <summary>Header for the data.</summary>
            [FieldOffset(0)]
            public RawInputHeader Header;
            /// <summary>Mouse raw input data.</summary>
            [FieldOffset(16)]
            public RawMouse Mouse;
            /// <summary>Keyboard raw input data.</summary>
            [FieldOffset(16)]
            public RAWKEYBOARD Keyboard;
            /// <summary>HID raw input data.</summary>
            [FieldOffset(16)]
            public RAWHID Hid;
        }
        [StructLayout(LayoutKind.Sequential)]
        internal struct RawInputHeader {
            /// <summary>Type of device the input is coming from.</summary>
            public RawInputType Type;
            /// <summary>Size of the packet of data.</summary>
            public int Size;
            /// <summary>Handle to the device sending the data.</summary>
            public IntPtr Device;
            /// <summary>wParam from the window message.</summary>
            public IntPtr wParam;
        }
        public bool LockForBuzzersOnly = true;
        public List<int> BuzzerDevices = new List<int>();
        public int GetDeviceID(Message message) {
            uint dwSize = 0;
            GetRawInputData(
                message.LParam,
                RID_INPUT,
                IntPtr.Zero,
                ref dwSize,
                (uint)Marshal.SizeOf(typeof(RawInputHeader))
            );
            
            IntPtr buffer = Marshal.AllocHGlobal((int)dwSize);
            GetRawInputData(
                message.LParam,
                RID_INPUT,
                buffer,
                ref dwSize,
                (uint)Marshal.SizeOf(typeof(RawInputHeader))
            );
            RawInput raw = (RawInput)Marshal.PtrToStructure(buffer, typeof(RawInput));
            Marshal.FreeHGlobal(buffer);
            if (raw.Mouse.ButtonFlags == RawMouseButtons.LeftDown || raw.Mouse.ButtonFlags == RawMouseButtons.RightDown) {
                return (int)raw.Header.Device;
            } else {
                return 0;
            }
        }
        public clsGetInputID(IntPtr hwnd) {
            RAWINPUTDEVICE[] rid = new RAWINPUTDEVICE[1];
            rid[0].usUsagePage = 0x01;
            rid[0].usUsage = 0x02;
            rid[0].dwFlags = RIDEV_INPUTSINK;
            rid[0].hwndTarget = hwnd;
            if (!RegisterRawInputDevices(rid, (uint)rid.Length, (uint)Marshal.SizeOf(rid[0]))) {
                throw new ApplicationException("Failed to register raw input device(s).");
            }
        }
    }
