                string Executable = "C:\\*******";
                using (Process p = new Process())
                {
                    // Redirect the output stream of the child process. 
                    p.StartInfo.FileName = Executable;
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardOutput = true;  //must be true to grab event
                    p.StartInfo.CreateNoWindow = true;  //false if you want to see the command window
                    p.EnableRaisingEvents = true;   //must be true to grab event
                    p.OutputDataReceived += p_WriteData;   //setup your output handler
                    p.Start();
                    p.BeginOutputReadLine();
                }
    private void p_WriteData(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
             string FixedOutput = MethodToFormatOutput(e.Data);  //do string manipulation here
              using(StreamWriter SW = new StreamWriter("C:\\output.txt",true)
                {
                  SW.WriteLine(FixedOutput);
                }
            }
        }
