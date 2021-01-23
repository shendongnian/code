    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Windows.Forms;
    namespace ProcessLauncherDemo
    {
        class ProcessLauncher : IDisposable
        {
            Form1 form;
            Process process;
            public ProcessLauncher(Form1 form)
            {
                this.form = form;
                process = new Process();
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.WorkingDirectory = @"C:\";
                process.StartInfo.FileName = Path.Combine(Environment.SystemDirectory, "cmd.exe");
                // Redirects the standard input so that commands can be sent to the shell.
                process.StartInfo.RedirectStandardInput = true;
                // Runs the specified command and exits the shell immediately.
                process.StartInfo.Arguments = @"/c ""C:\python27\python.exe -c ""import sys; print 'Test.';""""";
                process.OutputDataReceived += ProcessOutputDataHandler;
                process.ErrorDataReceived += ProcessErrorDataHandler;
            }
            public void Start()
            {
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
            }
            public void ProcessOutputDataHandler(object sendingProcess, DataReceivedEventArgs outLine)
            {
                form.Invoke(form.appendConsoleTextDelegate, new object[] { outLine.Data });
            }
            public void ProcessErrorDataHandler(object sendingProcess, DataReceivedEventArgs outLine)
            {
                form.Invoke(form.appendConsoleTextDelegate, new object[] { outLine.Data });
            }
            public void Dispose()
            {
                if (process != null)
                {
                    process.Dispose();
                }
            }
        }
    }
