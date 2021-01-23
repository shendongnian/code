using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
// Specify your namespace here
namespace <your.namespace>
{
    static class NativeMethods
    {
        // This is the Interop/WinAPI that will be used
        [DllImport("user32.dll")]
        static extern void SwitchToThisWindow(IntPtr hWnd, bool fUnknown);
    }
}
Main code:
// Under normal circumstances, only one process with one window exists
Process[] processes = Process.GetProcessesByName("ExternalApp.exe");
if (processes.Length > 0 && processes[0].MainWindowHandle != IntPtr.Zero)
{
    // Since this simulates alt-tab, it restores minimized windows to their previous state
    SwitchToThisWindow(process.MainWindowHandle, true);
    return true;
}
// Multiple things are happening here
// First, the ProgramFilesX86 variable automatically accounts for 32-bit or 64-bit systems and returns the correct folder
// Secondly, $-strings are the C# shortcut for string.format() (It automatically calls .ToString() on each variable contained in { })
// Thirdly, if the process was able to start, the return value is not null
try { if (Process.Start($"{System.Environment.SpecialFolder.ProgramFilesX86}\\ExternalApp\\ExternalApp.exe") != null) return true; }
catch
{
    // Code for handling an exception (probably FileNotFoundException)
    // ...
    return false;
}
// Code for when the external app was unable to start without producing an exception
// ...
return false;
I hope this provides a much simpler solution.
(General Rule: If a string value is ordinal, i.e. it belongs to something and isn't just a value, then it is better to get it programmatically. You'll save yourself a lot of trouble when changing things. In this case, I'm assuming that the install location can be converted to a global constant, and the .exe name can be found programmatically.)
