            public static void Restore(this Form form)
            {
                if (form.WindowState == FormWindowState.Minimized)
                {
                    var placement = new WindowPlacement();
                    placement.length = Marshal.SizeOf(placement);
                    NativeMethods.GetWindowPlacement(form.Handle, ref placement);
    
                    if ((placement.flags & RESTORETOMAXIMIZED) == RESTORETOMAXIMIZED)
                        form.WindowState = FormWindowState.Maximized;
                    else
                        form.WindowState = FormWindowState.Normal;
                }
    
                form.Show();
            }
    
     public struct WindowPlacement
            {
                public int length;
                public int flags;
                public int showCmd;
                public Point ptMinPosition;
                public Point ptMaxPosition;
                public Rectangle rcNormalPosition;
            }
    
            public const int RESTORETOMAXIMIZED = 0x2;
    
     [DllImport("user32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool GetWindowPlacement(IntPtr hWnd, ref WindowPlacement lpwndpl);
