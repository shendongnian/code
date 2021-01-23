    private static bool RunElevated(string args)
            {
                ProcessStartInfo processInfo = new ProcessStartInfo();
                processInfo.Verb = "runas";
                processInfo.FileName = Application.ExecutablePath;
                processInfo.Arguments = args;
                try
                {
                    Process.Start(processInfo);
                    return true;
                }
                catch (Exception)
                {
                    //Do nothing. Probably the user canceled the UAC window
                }
                return false;
            }
