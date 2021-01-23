    int ProcessId = GetProcessesByName("Your app here").FirstOrDefault().Id;
    private IntPtr SetHook(KeyboardHookHandler proc)
        {
            return SetWindowsHookEx(13, proc, GetModuleHandle(Process.GetProcessById(ProcessId).MainModule.ModuleName), GetWindowThreadProcessId(GetModuleHandle(Process.GetProcessById(ProcessId).MainModule.ModuleName), out int gay));
        }
        
