    public static void Main()
    {
        var result = new List<IntPtr>();
        var listHandle = GCHandle.Alloc(result);
    
        try
        {
            var windowHWnd = FindWindowByCaption(IntPtr.Zero, lpWindowName);
    
            EnumChildWindows(windowHWnd, (handle, pointer) =>
            {
                var gch = GCHandle.FromIntPtr(pointer);
                var list = gch.Target as List<IntPtr>;
                if (list == null)
                {
                    throw new InvalidCastException("GCHandle Target could not be cast as List<IntPtr>");
                }
                list.Add(handle);
    
                var sb = new StringBuilder(256);
                GetWindowCaption(handle, sb, 256);
                var text = sb.ToString();
    
                if (text == @"&No")
                {
                    PostMessage(handle, 0x0201, IntPtr.Zero, IntPtr.Zero);
                    PostMessage(handle, 0x0202, IntPtr.Zero, IntPtr.Zero);
                }
    
                return true;
            }, GCHandle.ToIntPtr(listHandle));
        }
        catch (Exception e)
        {
            MessageBox.Show(e.ToString());
        }
        finally
        {
            if (listHandle.IsAllocated)
            {
                listHandle.Free();
            }
        }
    }
    
    [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
    private static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);
    
    [DllImport("user32.dll", EntryPoint = "GetWindowText", CharSet = CharSet.Auto)]
    private static extern IntPtr GetWindowCaption(IntPtr hwnd, StringBuilder lpString, int maxCount);
    
    [return: MarshalAs(UnmanagedType.Bool)]
    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
