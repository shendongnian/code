    class Win32ApiUtils
    {
        // Don't declare a value for the Pack size. If you omit it, the correct value is used when  
        // marshaling and a single SHFILEOPSTRUCT can be used for both 32-bit and 64-bit operation.
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct SHFILEOPSTRUCT
        {
            public IntPtr hwnd;
            [MarshalAs(UnmanagedType.U4)]
            public int wFunc;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pFrom;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pTo;            
            public ushort fFlags;
            [MarshalAs(UnmanagedType.Bool)]
            public bool fAnyOperationsAborted;
            public IntPtr hNameMappings;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpszProgressTitle;
       }
    
       [DllImport("shell32.dll", CharSet = CharSet.Auto)]
       static extern int SHFileOperation(ref SHFILEOPSTRUCT FileOp);
       const int FO_DELETE = 3;
       const int FOF_ALLOWUNDO = 0x40;
       const int FOF_NOCONFIRMATION = 0x10; //Don't prompt the user.; 
    
       public static int DeleteFilesToRecycleBin(string filename)
       {
            SHFILEOPSTRUCT shf = new SHFILEOPSTRUCT();
            shf.wFunc = FO_DELETE;
            shf.fFlags = FOF_ALLOWUNDO | FOF_NOCONFIRMATION;
            shf.pFrom = filename + "\0";  // <--- this "\0" is critical !!!!!
            int result = SHFileOperation(ref shf);
            // Any value different from zero is an error to lookup 
            return result;
     
       }
   }
       foreach (ListViewItem item in listView1.SelectedItems)
       {
            int result = Win32ApiUtils.DeleteFilesToRecycleBin(item.SubItems[3].Text);
            if(result != 0) ...... // ??? throw ??? message to user and contine ???
       }
