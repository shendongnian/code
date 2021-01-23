     ProcessStartInfo proc = new ProcessStartInfo();
     proc.UseShellExecute = true;
     proc.WorkingDirectory = Environment.CurrentDirectory;
     proc.FileName = Application.ExecutablePath;
     proc.Verb = "runas"; //Required to run as Administrator
     try
     {
     Process.Start(proc);
  
     }
     catch
     {
       //The user refused to authorize
     }
     Application.Exit();  // Quit itself
