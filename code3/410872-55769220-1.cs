using System.Diagnostics;
// Setting fUnknown to true while calling this method produces the 
// same effect as alt-tabbing. 
// Thus, if the window is minimized, it is restored, and if it was 
// maximized when minimized, it is restored to a maximized state.
[System.Runtime.InteropServices.DllImport("user32.dll")]
private static extern void SwitchToThisWindow(IntPtr hWnd, bool fUnknown);
// Startup method
protected override void OnStartup(StartupEventArgs e)
{
    base.OnStartup(e);
    // Get all processes with the same name as this one
    Process current = Process.GetCurrentProcess();
    Process[] processes = Process.GetProcessesByName(current.ProcessName);
    // Handle the first process that's not this one
    foreach (Process process in processes) if (process.Id != current.Id)
        {
            // Bring the window into view if minimized and focus it
            SwitchToThisWindow(process.MainWindowHandle, true);
            // Quit this process
            Current.Shutdown(); return;
        }
    // Normal start code...
}
I hope this provides a much simpler solution.
**Note:** This only works if the target window exists. If a window was hidden via `Window.Hide()` or closed, then `process.MainWindowHandle` will equal 0, making `SwitchToThisWindow` throw an exception!
