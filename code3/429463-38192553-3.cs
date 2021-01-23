            private static bool _exiting;
        private static readonly object SynchObj = new object();
    public static void RestartAsAdmin(Form mainForm, params string[] commandLine)
        {
            lock (SynchObj)
            {
                if (Assembly.GetEntryAssembly() == null)
                {
                    throw new InvalidOperationException();
                }
                if (_exiting) return;
                _exiting = true;
                if (Environment.OSVersion.Version.Major < 6)
                {
                    return;
                }
                bool cancelExit = true;
                try
                {
                    for (int i = 0; i < Application.OpenForms.Count; i++)
                    {
                        Form f = Application.OpenForms[i];
                        MethodInvoker action = () =>
                        {
                            f.FormClosing += (sender, args) => cancelExit = args.Cancel;
                            f.Close();
                        };
                        if (f.InvokeRequired)
                        {
                            f.Invoke(action, f);
                        }
                        else
                        {
                            action();
                        }
                        if (cancelExit) break;
                    }
                    if (cancelExit) return;
                    Process.Start(new ProcessStartInfo
                    {
                        UseShellExecute = true,
                        WorkingDirectory = Environment.CurrentDirectory,
                        FileName = Application.ExecutablePath,
                        Arguments = commandLine.Length > 0 ? string.Join(" ", commandLine) : string.Empty,
                        Verb = "runas"
                    });
                    Application.Exit(new CancelEventArgs());
                }
                catch (Exception)
                {
                    // ignored
                }
                finally
                {
                    _exiting = false;
                }
            }
        }
