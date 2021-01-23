         process.StartInfo.RedirectStandardOutput = true;
         process.StartInfo.RedirectStandardError = true;
         process.StartInfo.UseShellExecute = false;
         process.OutputDataReceived += new DataReceivedEventHandler(ReadOutput);
         process.ErrorDataReceived += new DataReceivedEventHandler(ErrorOutput);
         process.Start();
         process.BeginOutputReadLine();
         process.BeginErrorReadLine();
         process.WaitForExit();
