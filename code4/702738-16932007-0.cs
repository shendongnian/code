       const string ns = @"root\cimv2";
       var host = "your host";
       var scope = new ManagementScope(string.Format(@"\\{0}\{1}", host, ns));
       scope.Connect();
    
    //List of logged in users
    
       using (var searcher = new ManagementObjectSearcher(scope, 
               new ObjectQuery("select * from Win32_LoggedOnUser")))
       {
    
              foreach (var logonUser in searcher.Get())
              {
                   //see MSDN for available properties of Win32_LoggedOnUser, 
                   //take into consideration "Dependent", "Antecedent" properties
              }
    
       }
    
    //list of processes
    
      using (var searcher = new ManagementObjectSearcher(scope, 
                      new ObjectQuery( "select * from Win32_SessionProcess")))
      {
           foreach (var sessProc in searcher.Get())
           {
                //see "Antecedent" property
           }
      }
