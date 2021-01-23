    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 21)]
    byte[] centralName = new byte[21];
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 21)]
    byte[] projectName = new byte[21];
    byte misc;
    public string CentralName {
        get {
            int i = Array.IndexOf(centralName, (byte)0);
            if (i < 0) i = centralName.Length;
            return Encoding.ASCII.GetString(centralName, 0, i);
        }
        set {
            Array.Clear(centralName, 0, centralName.Length);
            Encoding.ASCII.GetBytes(value, 0, value.Length, centralName, 0);
        } }
    public string ProjectName {
        get {
            int i = Array.IndexOf(projectName, (byte)0);
            if (i < 0) i = projectName.Length;
            return Encoding.ASCII.GetString(projectName, 0, i);
        }
        set {
            Array.Clear(projectName, 0, projectName.Length);
            Encoding.ASCII.GetBytes(value, 0, value.Length, projectName, 0);
        } }
