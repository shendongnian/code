    using (Process process = Process.Start(info))
    {
      if(process.WaitForExit())
      {
      StreamReader sr = process.StandardOutput;
      returnvalue = sr.ReadToEnd();
      }
    }
