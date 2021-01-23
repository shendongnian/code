    string processName = "calc";
    int processCount = 2;
    
    while ( true )
      {
      while ( Process.GetProcessesByName( processName ).Count() < processCount )
        {
        Process.Start( processName );
        }
    
      var tasks = from p in Process.GetProcessesByName( processName )
                  select Task.Factory.StartNew( p.WaitForExit );
      Task.WaitAll( tasks.ToArray() ); 
      }
