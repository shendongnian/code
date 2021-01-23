    using Microsoft.Win32; //for the registry class
    using System.Runtime.InteropServices; //for converting the PIDL
    //GetPathFromPIDL from matt.schechtman at https://stackoverflow.com/a/4318663
    [DllImport("shell32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool SHGetPathFromIDListW(IntPtr pidl, MarshalAs(UnmanagedType.LPTStr)] StringBuilder pszPath);
    private string GetPathFromPIDL(byte[] byteCode)
    {
        //MAX_PATH = 260
        StringBuilder builder = new StringBuilder(260);
        IntPtr ptr = IntPtr.Zero;
        GCHandle h0 = GCHandle.Alloc(byteCode, GCHandleType.Pinned);
        try
        {
            ptr = h0.AddrOfPinnedObject();
        }
        finally
        {
            h0.Free();
        }
        SHGetPathFromIDListW(ptr, builder);
        return builder.ToString();
    }
    public void OnClick_Button_OpenFile(object sender, RoutedEventArgs e)
    {
        string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\ComDlg32\\OpenSavePidlMRU\\txt";
        RegistryKey rk = Registry.CurrentUser.OpenSubKey(RegistryPath);
        byte[] mrulistex = (byte[])rk.GetValue("MRUListEx");
        byte Last = mrulistex[0];
        byte[] LastPathByteArray = (byte[])rk.GetValue(Last.ToString());
        string LastPath = GetPathFromPIDL(LastPathByteArray);
        // Configure open file dialog box
        Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();`
        dlg.InitialDirectory = LastPath;
        result = dlg.ShowDialog();
        if (result == true)
        {
            string filename = dlg.FileName;
        }
        //etc etc, rest of your code
    }
