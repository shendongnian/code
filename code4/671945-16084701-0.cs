        [DllImport("User32.dll")]
        public static extern int SetDisplayConfig(uint numPathArrayElements, [In] DisplayConfigPathInfo[] pathArray,
                                                  uint numModeInfoArrayElements, [In] DisplayConfigModeInfo[] modeInfoArray,
                                                  SdcFlags flags);
        [DllImport("User32.dll")]
        public static extern int QueryDisplayConfig(QueryDisplayFlags flags, ref int numPathArrayElements,
                                                [Out] DisplayConfigPathInfo[] pathInfoArray, 
                                                ref int modeInfoArrayElements,
                                                [Out] DisplayConfigModeInfo[] modeInfoArray,
                                                IntPtr z);
