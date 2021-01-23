    [DllImport("shell32.dll")]
    public static extern IntPtr ExtractIcon(IntPtr hInst, string file, int nIconIndex);
    [DllImport("user32.dll", SetLastError = true)]
    static extern bool DestroyIcon(IntPtr hIcon);
    /// <summary>
    /// Sets icon from .exe or .dll into form object
    /// </summary>
    /// <param name="iIconIndex">Icon index to use.</param>
    /// <param name="form">Form to assign to given icon</param>
    /// <returns>true if ok, false if failed.</returns>
    bool SetIcon( object form, int iIconIndex, String dllOrExe = null )
    {
        if( dllOrExe == null )
            dllOrExe = System.Reflection.Assembly.GetExecutingAssembly().Location;
        IntPtr hIcon = ExtractIcon(IntPtr.Zero, dllOrExe, iIconIndex);
            
        if( hIcon == IntPtr.Zero )
            return false;
        Icon icon = (Icon) Icon.FromHandle(hIcon).Clone();
        DestroyIcon(hIcon);
        form.GetType().GetProperty("Icon").SetValue(form, icon);
        return true;
    }
