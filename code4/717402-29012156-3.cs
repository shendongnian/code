    #if !WIN64
     [StructLayout(LayoutKind.Sequential, Pack = 2, CharSet = CharSet.Unicode)]
    #else  
     [StructLayout(LayoutKind.Sequential, Pack = 8, CharSet = CharSet.Unicode)]
    #endif
            public struct SP_DRVINFO_DATA 
    	    { 
    	        public int cbSize; 
    	        public uint DriverType; 
    	        public UIntPtr Reserved; 
    	        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)] 
    	        public string Description; 
    	        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)] 
    	        public string MfgName; 
    	        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)] 
    	        public string ProviderName;
    	        public System.Runtime.InteropServices.ComTypes.FILETIME DriverDate; 
    	        public ulong DriverVersion; 
    	   }
    
    
    #if !WIN64
     [StructLayout(LayoutKind.Sequential, Pack = 2, CharSet = CharSet.Unicode)]
    #else  
     [StructLayout(LayoutKind.Sequential, Pack = 8, CharSet = CharSet.Unicode)]
    #endif
            public struct SP_DRVINFO_DETAIL_DATA
            {
                public Int32 cbSize;
                public System.Runtime.InteropServices.ComTypes.FILETIME InfDate;
                public Int32 CompatIDsOffset;
                public Int32 CompatIDsLength;
                public IntPtr Reserved;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
                public String SectionName;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
                public String InfFileName;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
                public String DrvDescription;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
                public String HardwareID;
            };
