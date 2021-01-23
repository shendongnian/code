    [Serializable]
    public struct newLeads
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5000)]
        public string id;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5000)]
        public string first_name;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5000)]
        public string last_name;
    }
