    private void ConvertVideo(string srcURL)
    {
        string ffmpegURL = @"C:\ffmpeg.exe";
        DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\");
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = ffmpegURL;
        startInfo.Arguments = string.Format("-i \"{0}\" -ar 44100 -f mp3 -", srcURL);
        startInfo.WorkingDirectory = directoryInfo.FullName;
        startInfo.UseShellExecute = false;
        startInfo.RedirectStandardOutput = true;
        startInfo.RedirectStandardInput = true;
        startInfo.RedirectStandardError = true;
        startInfo.CreateNoWindow = false;
        startInfo.WindowStyle = ProcessWindowStyle.Normal;
        using (Process process = new Process())
        {
            process.StartInfo = startInfo;
            process.EnableRaisingEvents = true;
            process.ErrorDataReceived += new DataReceivedEventHandler(process_ErrorDataReceived);
            process.OutputDataReceived += new DataReceivedEventHandler(process_OutputDataReceived);
            process.Exited += new EventHandler(process_Exited);
            try
            {
                process.Start();
                process.BeginErrorReadLine();
                process.BeginOutputReadLine();
                process.WaitForExit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                process.ErrorDataReceived -= new DataReceivedEventHandler(process_ErrorDataReceived);
                process.OutputDataReceived -= new DataReceivedEventHandler(process_OutputDataReceived);
                process.Exited -= new EventHandler(process_Exited);
            }
        }
    }
    void process_OutputDataReceived(object sender, DataReceivedEventArgs e)
    {
        if (e.Data != null)
        {
            byte[] b = System.Text.Encoding.Unicode.GetBytes(e.Data);
            // If you are in ASP.Net, you do a 
            // Response.OutputStream.Write(b)
            // to send the converted stream as a response
        }
    }
    void process_Exited(object sender, EventArgs e)
    {
        // Conversion is finished.
        // In ASP.Net, do a Response.End() here.
    }
