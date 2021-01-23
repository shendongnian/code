	[System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        
	public static uint WM_COPYDATA = 74;
	//from swhistlesoft
	public static IntPtr IntPtrAlloc<T>(T param)
        { 
            IntPtr retval = System.Runtime.InteropServices.Marshal.AllocHGlobal(System.Runtime.InteropServices.Marshal.SizeOf(param)); 
            System.Runtime.InteropServices.Marshal.StructureToPtr(param, retval, false); 
            return (retval); 
        }
	//from swhistlesoft
        public static void IntPtrFree(IntPtr preAllocated) 
        { 
            if (IntPtr.Zero == preAllocated) throw (new Exception("Go Home")); 
            System.Runtime.InteropServices.Marshal.FreeHGlobal(preAllocated); 
            preAllocated = IntPtr.Zero; 
        }
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        struct COPYDATASTRUCT
        {
            public uint dwData;
            public int cbData;
            public IntPtr lpData;
        }
        /// <summary>
        /// Dot net version of AppInfo structure. Any changes to the structure needs reflecting here.
        /// struct must be a fixed size for marshalling to work, hence the SizeConst entries
        /// </summary>
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 1)]
        struct AppInfoDotNet
	    {
		    public int	 nVersion;            
                        
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 9)]
            public string test;
	    };
