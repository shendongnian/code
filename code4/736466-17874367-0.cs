        internal static void executeCommand(string command, bool waitForExit,
        bool hideWindow, bool runAsAdministrator)
        {
            System.Diagnostics.ProcessStartInfo psi =
            new System.Diagnostics.ProcessStartInfo("cmd", "/C " + command);
            if (hideWindow)
            {
                psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            }
            if (runAsAdministrator)
            {
                psi.Verb = "runas";
            }
            if (waitForExit)
            {
                System.Diagnostics.Process.Start(psi).WaitForExit();
            }
            else
            {
                System.Diagnostics.Process.Start(psi);
            }
        }
