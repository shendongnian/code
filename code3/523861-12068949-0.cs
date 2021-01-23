    private static void Main()
    {
        using (var managementClass = new ManagementClass("Win32_Process"))
        {
            var processInfo = new ManagementClass("Win32_ProcessStartup");
            processInfo.Properties["CreateFlags"].Value = 0x00000008;
            var inParameters = managementClass.GetMethodParameters("Create");
            inParameters["CommandLine"] = "notepad.exe";
            inParameters["ProcessStartupInformation"] = processInfo;
            var result = managementClass.InvokeMethod("Create", inParameters, null);
            if ((result != null) && ((uint)result.Properties["ReturnValue"].Value != 0))
            {
                Console.WriteLine("Process ID: {0}", result.Properties["ProcessId"].Value);
            }
        }
        Console.ReadKey();
    }
