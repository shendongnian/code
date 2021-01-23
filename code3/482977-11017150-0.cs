    public const int TARGET_OS_MAC = 1; 
    public const int TARGET_OS_WIN32 = 0; 
    public const int TARGET_OS_UNIX = 0; 
    public const int TARGET_OS_EMBEDDED = 0; 
    public const int TARGET_OS_IPHONE = 1;  
    public const int TARGET_IPHONE_SIMULATOR = 1; 
 
    #if __MACH__ 
        public const int TARGET_RT_MAC_MACHO = 1; 
        public const int TARGET_RT_MAC_CFM = 0; 
    #else 
        public const int TARGET_RT_MAC_MACHO = 0; 
        public const int TARGET_RT_MAC_CFM = 1; 
    #endif 
