using System.Diagnostics;
// If fUnknown is true, calling the method produces the same effect as alt-tabbing
// Thus, if the window is minimized, it is restored
// If it was minimized while maximized, it is restored maximized
// If it is behind other windows, it is sent to the front
[System.Runtime.InteropServices.DllImport("user32.dll")]
private static extern void SwitchToThisWindow(IntPtr hWnd, bool fUnknown);
// Startup method
protected override void OnStartup(StartupEventArgs e)
{
    base.OnStartup(e); //part of the override
    // Get all processes with the same name as this one
    Process current = Process.GetCurrentProcess();
    Process[] processes = Process.GetProcessesByName(current.ProcessName);
    // Skip handling for this process
    foreach (Process process in processes) if (process.Id != current.Id)
        {
            // Bring the window into view if minimized and focus it
            SwitchToThisWindow(process.MainWindowHandle, true);
            // Quit the application
            Current.Shutdown(); return;
        }
    // Normal start code...
}
I hope this provides a much simpler solution.
**Note:** This only works if the target window exists. If a window was hidden via `Window.Hide()` or closed, then `process.MainWindowHandle` will equal 0, making `SwitchToThisWindow` throw an exception!
