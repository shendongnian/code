    string args = string.Format("-density 200 \"{0}\" -quality 40 \"{1}\\{2}\"", file.FullName, imageFolder, file.Name.Replace("pdf", "png"));
    using (Process proc = new Process {
        StartInfo = {
            Arguments = args,
            FileName = @"c:\imagemagick\convert",
            UseShellExecute = false,
            CreateNoWindow = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true
        }
    }) {
        proc.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
        proc.ErrorDataReceived += new DataReceivedEventHandler(p_ErrorDataReceived);
        proc.Start();
        proc.WaitForExit();
    }
