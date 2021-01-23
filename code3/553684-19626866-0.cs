    private static HookProc hookProcDelegate;
    private static void InstallHook()
    {
        if (Program.hWndProcHook == IntPtr.Zero)
        {
            Console.WriteLine("Hooking...");
            hookProcDelegate = new HookProc(WndProcHookCallback);
            Program.hWndProcHook = SetWindowsHookEx(
                WH_CALLWNDPROC,
                hookProcDelegate,
                GetModuleHandle(null),
                GetCurrentThreadId());
            if (Program.hWndProcHook != IntPtr.Zero)
                Console.WriteLine("Hooked successfully.");
            else
                Console.WriteLine("Failed to hook.");
        }
    }
