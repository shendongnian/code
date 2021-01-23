    public static void RestartAsAdmin(Form mainForm, params string[] commandLine)
        {
            if (Environment.OSVersion.Version.Major < 6)
            {
                return;
            }
            try
            {
                Process.Start(new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    WorkingDirectory = Environment.CurrentDirectory,
                    FileName = Application.ExecutablePath,
                    Arguments = commandLine.Length > 0 ? string.Join(" ", commandLine) : string.Empty,
                    Verb = "runas"
                });
            }
            catch
            {
                return;
            }
            mainForm.Close(); // may try Application.Exit() depends main form closing handler
        }
        public static void ApplicationRestart(params string[] commandLine)
        {
            if (Environment.OSVersion.Version.Major < 6)
            {
                return;
            }
            try
            {
                Process.Start(new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    WorkingDirectory = Environment.CurrentDirectory,
                    FileName = Application.ExecutablePath,
                    Arguments = commandLine.Length > 0 ? string.Join(" ", commandLine) : string.Empty
                });
            }
            catch
            {
                return;
            }
            Application.Exit();
        }
