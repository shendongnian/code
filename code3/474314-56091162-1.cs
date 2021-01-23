    public class ProcessSettings
    {
        public string FileName { get; set; }
        public string Arguments { get; set; } = "";
        public string WorkingDirectory { get; set; } = "";
        public string InputText { get; set; } = null;
        public int Timeout_milliseconds { get; set; } = -1;
        public bool ReadOutput { get; set; }
        public bool ShowWindow { get; set; }
        public bool KeepWindowOpen { get; set; }
        public bool StartAsAdministrator { get; set; }
        public string StartAsUsername { get; set; }
        public string StartAsUsername_Password { get; set; }
        public string StartAsUsername_Domain { get; set; }
        public bool DontReadExitCode { get; set; }
        public bool ThrowExceptions { get; set; }
        public CancellationToken CancellationToken { get; set; }
    }
    public class ProcessOutputReader   // Optional, to get the output while executing instead only as result at the end
    {
        public event TextEventHandler OutputChanged;
        public event TextEventHandler OutputErrorChanged;
        public void UpdateOutput(string text)
        {
            OutputChanged?.Invoke(this, new TextEventArgs(text));
        }
        public void UpdateOutputError(string text)
        {
            OutputErrorChanged?.Invoke(this, new TextEventArgs(text));
        }
        public delegate void TextEventHandler(object sender, TextEventArgs e);
        public class TextEventArgs : EventArgs
        {
            public string Text { get; }
            public TextEventArgs(string text) { Text = text; }
        }
    }
    public class ProcessResult
    {
        public string Output { get; set; }
        public string OutputError { get; set; }
        public int ExitCode { get; set; }
        public bool WasCancelled { get; set; }
        public bool WasSuccessful { get; set; }
    }
    public class ProcessStarter
    {
        public ProcessResult Execute(ProcessSettings settings, ProcessOutputReader outputReader = null)
        {
            return Task.Run(() => ExecuteAsync(settings, outputReader)).GetAwaiter().GetResult();
        }
        public async Task<ProcessResult> ExecuteAsync(ProcessSettings settings, ProcessOutputReader outputReader = null)
        {
            if (settings.FileName == null) throw new ArgumentNullException(nameof(ProcessSettings.FileName));
            if (settings.Arguments == null) throw new ArgumentNullException(nameof(ProcessSettings.Arguments));
            var cmdSwitches = "/Q " + (settings.KeepWindowOpen ? "/K" : "/C");
            var arguments = $"{cmdSwitches} {settings.FileName} {settings.Arguments}";
            var startInfo = new ProcessStartInfo("cmd", arguments)
            {
                UseShellExecute = false,
                RedirectStandardOutput = settings.ReadOutput,
                RedirectStandardError = settings.ReadOutput,
                RedirectStandardInput = settings.InputText != null,
                CreateNoWindow = !(settings.ShowWindow || settings.KeepWindowOpen),
            };
            if (!string.IsNullOrWhiteSpace(settings.StartAsUsername))
            {
                if (string.IsNullOrWhiteSpace(settings.StartAsUsername_Password))
                    throw new ArgumentNullException(nameof(ProcessSettings.StartAsUsername_Password));
                if (string.IsNullOrWhiteSpace(settings.StartAsUsername_Domain))
                    throw new ArgumentNullException(nameof(ProcessSettings.StartAsUsername_Domain));
                if (string.IsNullOrWhiteSpace(settings.WorkingDirectory))
                    settings.WorkingDirectory = Path.GetPathRoot(Path.GetTempPath());
                startInfo.UserName = settings.StartAsUsername;
                startInfo.PasswordInClearText = settings.StartAsUsername_Password;
                startInfo.Domain = settings.StartAsUsername_Domain;
            }
            var output = new StringBuilder();
            var error = new StringBuilder();
            if (!settings.ReadOutput)
            {
                output.AppendLine($"Enable {nameof(ProcessSettings.ReadOutput)} to get Output");
            }
            if (settings.StartAsAdministrator)
            {
                startInfo.Verb = "runas";
                startInfo.UseShellExecute = true;  // Verb="runas" only possible with ShellExecute=true.
                startInfo.RedirectStandardOutput = startInfo.RedirectStandardError = startInfo.RedirectStandardInput = false;
                output.AppendLine("Output couldn't be read when started as Administrator");
            }
            if (!string.IsNullOrWhiteSpace(settings.WorkingDirectory))
            {
                startInfo.WorkingDirectory = settings.WorkingDirectory;
            }
            var result = new ProcessResult();
            var taskCompletionSourceProcess = new TaskCompletionSource<bool>();
            var process = new Process { StartInfo = startInfo, EnableRaisingEvents = true };
            try
            {
                process.OutputDataReceived += (sender, e) =>
                {
                    if (e?.Data != null)
                    {
                        output.AppendLine(e.Data);
                        outputReader?.UpdateOutput(e.Data);
                    }
                };
                process.ErrorDataReceived += (sender, e) =>
                {
                    if (e?.Data != null)
                    {
                        error.AppendLine(e.Data);
                        outputReader?.UpdateOutputError(e.Data);
                    }
                };
                process.Exited += (sender, e) =>
                {
                    try { (sender as Process)?.WaitForExit(); } catch (InvalidOperationException) { }
                    taskCompletionSourceProcess.TrySetResult(false);
                };
                var success = false;
                try
                {
                    process.Start();
                    success = true;
                }
                catch (System.ComponentModel.Win32Exception ex)
                {
                    if (ex.NativeErrorCode == 1223)
                    {
                        error.AppendLine("AdminRights request Cancelled by User!! " + ex);
                        if (settings.ThrowExceptions) taskCompletionSourceProcess.SetException(ex); else taskCompletionSourceProcess.TrySetResult(false);
                    }
                    else
                    {
                        error.AppendLine("Win32Exception thrown: " + ex);
                        if (settings.ThrowExceptions) taskCompletionSourceProcess.SetException(ex); else taskCompletionSourceProcess.TrySetResult(false);
                    }
                }
                catch (Exception ex)
                {
                    error.AppendLine("Exception thrown: " + ex);
                    if (settings.ThrowExceptions) taskCompletionSourceProcess.SetException(ex); else taskCompletionSourceProcess.TrySetResult(false);
                }
                if (success && startInfo.RedirectStandardOutput)
                    process.BeginOutputReadLine();
                if (success && startInfo.RedirectStandardError)
                    process.BeginErrorReadLine();
                if (success && startInfo.RedirectStandardInput)
                {
                    var writeInputTask = Task.Factory.StartNew(() => WriteInputTask());
                }
                async void WriteInputTask()
                {
                    var processRunning = true;
                    await Task.Delay(50).ConfigureAwait(false);
                    try { processRunning = !process.HasExited; } catch { }
                    while (processRunning)
                    {
                        if (settings.InputText != null)
                        {
                            try
                            {
                                await process.StandardInput.WriteLineAsync(settings.InputText).ConfigureAwait(false);
                                await process.StandardInput.FlushAsync().ConfigureAwait(false);
                                settings.InputText = null;
                            }
                            catch { }
                        }
                        await Task.Delay(5).ConfigureAwait(false);
                        try { processRunning = !process.HasExited; } catch { processRunning = false; }
                    }
                }
                if (success && settings.CancellationToken != default(CancellationToken))
                    settings.CancellationToken.Register(() => taskCompletionSourceProcess.TrySetResult(true));
                if (success && settings.Timeout_milliseconds > 0)
                    new CancellationTokenSource(settings.Timeout_milliseconds).Token.Register(() => taskCompletionSourceProcess.TrySetResult(true));
                var taskProcess = taskCompletionSourceProcess.Task;
                await taskProcess.ConfigureAwait(false);
                if (taskProcess.Result == true) // process was cancelled by token or timeout
                {
                    if (!process.HasExited)
                    {
                        result.WasCancelled = true;
                        error.AppendLine("Process was cancelled!");
                        try
                        {
                            process.CloseMainWindow();
                            await Task.Delay(30).ConfigureAwait(false);
                            if (!process.HasExited)
                            {
                                process.Kill();
                            }
                        }
                        catch { }
                    }
                }
                result.ExitCode = -1;
                if (!settings.DontReadExitCode)     // Reason: sometimes, like when timeout /t 30 is started, reading the ExitCode is only possible if the timeout expired, even if process.Kill was called before.
                {
                    try { result.ExitCode = process.ExitCode; }
                    catch { output.AppendLine("Reading ExitCode failed."); }
                }
                process.Close();
            }
            finally { var disposeTask = Task.Factory.StartNew(() => process.Dispose()); }    // start in new Task because disposing sometimes waits until the process is finished, for example while executing following command: ping -n 30 -w 1000 127.0.0.1 > nul
            if (result.ExitCode == -1073741510 && !result.WasCancelled)
            {
                error.AppendLine($"Process exited by user!");
            }
            result.WasSuccessful = !result.WasCancelled && result.ExitCode == 0;
            result.Output = output.ToString();
            result.OutputError = error.ToString();
            return result;
        }
    }
