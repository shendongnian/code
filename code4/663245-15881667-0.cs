    public struct DFS_STORAGE_INFO_1 {
        public DFS_STORAGE_STATE State;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string ServerName;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string ShareName;
        DFS_TARGET_PRIORITY TargetPriority;
    }
