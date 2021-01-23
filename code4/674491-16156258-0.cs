    foreach (string line in textBox1.Lines)
    {
        string cmdLine = textDir.Text + "\\" + line + " " + textDir.Text + "\\" + line.Replace("dl_", "dll");
        var process = new Process
            {
                StartInfo = new ProcessStartInfo
                    {
                        FileName = "expand.exe",
                        Arguments = cmdLine.Replace(Environment.NewLine, string.Empty),
                        WindowStyle = ProcessWindowStyle.Normal,
                        UseShellExecute = true
                    }
            };
        process.Start();
        process.WaitForExit();
    }
