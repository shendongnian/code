    [DllImportAttribute("uxtheme.dll")]
    private static extern int SetWindowTheme(IntPtr hWnd, string appname, string idlist);
    [DllImport("user32")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr i);
    // get first child:
    public static IntPtr GetFirstChild(IntPtr parent)
    {
        List<IntPtr> result = new List<IntPtr>();
        GCHandle listHandle = GCHandle.Alloc(result);
        try
        {
            EnumWindowProc childProc = new EnumWindowProc(EnumWindow);
            EnumChildWindows(parent, childProc, GCHandle.ToIntPtr(listHandle));
        }
        finally
        {
            if (listHandle.IsAllocated)
                listHandle.Free();
        }
        return result[0];
    }
    // Callback method to be used when enumerating windows:
    private static bool EnumWindow(IntPtr handle, IntPtr pointer)
    {
        GCHandle gch = GCHandle.FromIntPtr(pointer);
        List<IntPtr> list = gch.Target as List<IntPtr>;
        if (list == null)
            throw new InvalidCastException("GCHandle Target could not be cast as List<IntPtr>");
        list.Add(handle);
        return true;
    }
    // Delegate for the EnumChildWindows method:
    public delegate bool EnumWindowProc(IntPtr hWnd, IntPtr parameter);
    protected override void OnHandleCreated(EventArgs e)
    {
        SetWindowTheme(GetFirstChild(this.Handle), "", "");
        base.OnHandleCreated(e);
    }
