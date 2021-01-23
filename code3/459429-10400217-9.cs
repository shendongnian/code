    ProcessStartInfo info = new ProcessStartInfo();
    info.FileName = "notepad";
    info.UseShellExecute = true;
    info.WindowStyle = ProcessWindowStyle.Hidden;
    Process p = Process.Start(info);
    p.WaitForInputIdle();
    IntPtr HWND = FindWindow(null, "Untitled - Notepad");
    System.Threading.Thread.Sleep(1000);
            
    ShowWindow(HWND, SW_SHOW);
    EnableWindow(HWND, true);
