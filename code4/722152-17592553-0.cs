                //The following security adjustments are necessary to give the new 
                //process sufficient permission to run in the service's window station
                //and desktop. This uses classes from the AsproLock library also from 
                //Asprosys.
                IntPtr hWinSta = NativeMethods.GetProcessWindowStation();
                WindowStationSecurity ws = new WindowStationSecurity(hWinSta,
                  System.Security.AccessControl.AccessControlSections.Access);
                ws.AddAccessRule(new WindowStationAccessRule(userPassDto.Usuario,
                    WindowStationRights.AllAccess, System.Security.AccessControl.AccessControlType.Allow));
                ws.AcceptChanges();
                IntPtr hDesk = NativeMethods.GetThreadDesktop(NativeMethods.GetCurrentThreadId());
                DesktopSecurity ds = new DesktopSecurity(hDesk,
                    System.Security.AccessControl.AccessControlSections.Access);
                ds.AddAccessRule(new DesktopAccessRule(userPassDto.Usuario,
                    DesktopRights.AllAccess, System.Security.AccessControl.AccessControlType.Allow));
                ds.AcceptChanges();
    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr GetProcessWindowStation();
    
    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr GetThreadDesktop(int dwThreadId);
    
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern int GetCurrentThreadId();
