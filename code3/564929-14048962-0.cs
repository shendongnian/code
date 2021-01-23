    public partial class Form1 : Form
    {    
    [DllImport("user32")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr i);
    [DllImport("user32.dll")]
    static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
    [DllImport("user32.dll")]
    static extern bool GetWindowRect(IntPtr hWnd, out RECT rect);    
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;        // x position of upper-left corner
        public int Top;         // y position of upper-left corner
        public int Right;       // x position of lower-right corner
        public int Bottom;      // y position of lower-right corner
    }    
    
    private System.IntPtr hWnd;
    private void button1_Click(object sender, EventArgs e)
    {
        Process p = Process.Start(@"C:\Program Files\Winamp\winamp.exe");       
        try
        {
            do
            {
                p.Refresh();
            }
            while (p.MainWindowHandle.ToInt32() == 0);
    
            hWnd = new IntPtr(p.MainWindowHandle.ToInt32());
        }
        catch (Exception ex)
        {
            //Do some stuff...
            throw;
        }
    }
    
    private void button2_Click(object sender, EventArgs e)
    {
        //Make sure we have a handle to the shelled exe
        if (hWnd == new IntPtr(0)) return;
        ResizeExternalExeChildWindows(hWnd);
    }
    
    private void ResizeExternalExeChildWindows(IntPtr parent)
    {
        List<IntPtr> childWindows = GetChildWindows(hWnd);
        foreach (IntPtr childWindow in childWindows)
        {
            RECT rect;
            GetWindowRect(childWindow, out rect);
            int width = rect.Right - rect.Left;
            int height = rect.Bottom - rect.Top;
            MoveWindow(hWnd, 0, 0, width, height, true);
        }
    }
    
    // <summary>
    /// Returns a list of child windows
    /// </summary>
    /// <param name="parent">Parent of the windows to return</param>
    /// <returns>List of child windows</returns>
    public static List<IntPtr> GetChildWindows(IntPtr parent)
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
        return result;
    }
    
    /// <summary>
    /// Callback method to be used when enumerating windows.
    /// </summary>
    /// <param name="handle">Handle of the next window</param>
    /// <param name="pointer">Pointer to a GCHandle that holds a reference to the list to fill</param>
    /// <returns>True to continue the enumeration, false to bail</returns>
    private static bool EnumWindow(IntPtr handle, IntPtr pointer)
    {
        GCHandle gch = GCHandle.FromIntPtr(pointer);
        List<IntPtr> list = gch.Target as List<IntPtr>;
    if (list == null)
    {
        throw new InvalidCastException("GCHandle Target could not be cast as List<IntPtr>");
    }
    list.Add(handle);
    //  You can modify this to check to see if you want to cancel the operation, then return a null here
    return true;
    }
    
    /// <summary>
    /// Delegate for the EnumChildWindows method
    /// </summary>
    /// <param name="hWnd">Window handle</param>
    /// <param name="parameter">Caller-defined variable; we use it for a pointer to our list</param>
    /// <returns>True to continue enumerating, false to bail.</returns>
    public delegate bool EnumWindowProc(IntPtr hWnd, IntPtr parameter);
    
    }
    }
