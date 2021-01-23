     Process process = new Process();
     process.StartInfo.FileName = "Data/yle-dl/yle-dl.exe";
     process.StartInfo.Arguments = "-o pasila.flv http://areena.yle.fi/tv/1755554 --rtmpdump rtmpdump.exe ";
     process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
     process.StartInfo.CreateNoWindow = true;
     process.StartInfo.RedirectStandardOutput = true;
     process.StartInfo.RedirectStandardError = true;
     process.StartInfo.UseShellExecute = false;
     process.OutputDataReceived += new DataReceivedEventHandler(ReadOutput);
     process.ErrorDataReceived += new DataReceivedEventHandler(ReadOutput);
     process.Start();
     process.BeginOutputReadLine();
     process.BeginErrorReadLine();
     process.WaitForExit();
  
      private static void ReadOutput(object sender, DataReceivedEventArgs e)
      {
         if (e.Data != null)
         {
           Match m = Regex.Match(e.Data, "(\\d+)[^0-9]*(\\d+)[^0-9]*(\\d+)[^0-9]");
           if (m.Success)
           {
            textBox1.Text = m.Result("$1");
            string time = m.Result("$2");
            string percent = m.Result("$3");
           }
         }
      }
