    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Timers;
    namespace DummyFormsApplication
    {
        class ProcessLauncher : IDisposable
        {
            private Form1 form;
            private Process process;
            private bool running;
            public bool InteractiveMode
            {
                get;
                private set;
            }
       
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
                process.OutputDataReceived +=new DataReceivedEventHandler(process_OutputDataReceived);
                process.ErrorDataReceived += new DataReceivedEventHandler(process_ErrorDataReceived);
                process.Exited += new EventHandler(process_Exited);
            }
            public void Start()
            {
                if (running == false)
                {
                    running = true;
                    InteractiveMode = true;
                    // Runs the specified command and exits the shell immediately upon completion.
                    process.StartInfo.Arguments = @"/c ""C:\python27\python.exe -i""";
                    process.Start();
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();
                }
            }
            public void Start(string scriptFileName)
            {
                if (running == false)
                {
                    running = true;
                    InteractiveMode = false;
                    // Runs the specified command and exits the shell immediately upon completion.
                    process.StartInfo.Arguments = string.Format(@"/c ""C:\python27\python.exe ""{0}""""", scriptFileName);
                }
            }
            public void Abort()
            {
                process.Kill();
            }
            public void SendInput(string input)
            {
                process.StandardInput.Write(input);
                process.StandardInput.Flush();
            }
            private void process_OutputDataReceived(object sendingProcess, DataReceivedEventArgs outLine)
            {
                if (outLine.Data != null)
                {
                    form.Invoke(form.appendConsoleTextDelegate, new object[] { outLine.Data });
                }
            }
            private void process_ErrorDataReceived(object sendingProcess, DataReceivedEventArgs outLine)
            {
                if (outLine.Data != null)
                {
                    form.Invoke(form.appendConsoleTextDelegate, new object[] { outLine.Data });
                }
            }
            private void process_Exited(object sender, EventArgs e)
            {
                running = false;
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
