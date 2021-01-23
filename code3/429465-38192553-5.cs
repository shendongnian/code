            private static bool _exiting;
        private static readonly object SynchObj = new object();
            public static void ApplicationRestart(params string[] commandLine)
        {
            lock (SynchObj)
            {
                if (Assembly.GetEntryAssembly() == null)
                {
                    throw new NotSupportedException("RestartNotSupported");
                }
                if (_exiting)
                {
                    return;
                }
                _exiting = true;
                if (Environment.OSVersion.Version.Major < 6)
                {
                    return;
                }
                bool cancelExit = true;
                try
                {
                    List<Form> openForms = Application.OpenForms.OfType<Form>().ToList();
                    for (int i = openForms.Count - 1; i >= 0; i--)
                    {
                        Form f = openForms[i];
                        if (f.InvokeRequired)
                        {
                            f.Invoke(new MethodInvoker(() =>
                            {
                                f.FormClosing += (sender, args) => cancelExit = args.Cancel;
                                f.Close();
                            }));
                        }
                        else
                        {
                            f.FormClosing += (sender, args) => cancelExit = args.Cancel;
                            f.Close();
                        }
                        if (cancelExit) break;
                    }
                    if (cancelExit) return;
                    Process.Start(new ProcessStartInfo
                    {
                        UseShellExecute = true,
                        WorkingDirectory = Environment.CurrentDirectory,
                        FileName = Application.ExecutablePath,
                        Arguments = commandLine.Length > 0 ? string.Join(" ", commandLine) : string.Empty
                    });
                    
                    Application.Exit(new CancelEventArgs());
                }
                finally
                {
                    _exiting = false;
                }
            }
        }
