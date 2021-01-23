    Process Currentproc = Process.GetCurrentProcess();
    Process[] procByName=Process.GetProcessesByName("notepad");  //Write the name of your exe file in inverted commas
    if(procByName.Length>1)
    {
      MessageBox.Show("Application is already running");
      App.Current.Shutdown();
     }
