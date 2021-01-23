    using (Process process = Process.Start(info))
    {
      if(process.WaitForExit(myTimeOutInMilliseconds))
      {
      StreamReader sr = process.StandardOutput;
      returnvalue = sr.ReadToEnd();
      }
    }
