    var videoFileFormats = new List<string>
    {
      {".3gp"},
       {".mp4"} //etc.. 
    };
    
    var players = new List<string>
    {
         {"wmplayer"} //etc..
    };
    
     var processes = Process.GetProcesses();
         
     foreach (var proc in processes) {
           try {
        
             string appName = proc.ProcessName;
             string appFileName = proc.MainModule.FileName;
             string appExt = Path.GetExtension(appFileName);
                 
             if (videoFileFormats.Contains(appExt) || players.Contains(appName)) {
                   //do something..
                   //found..
             }
            } catch (Exception E) {
                  //it's because you can't get some process of system.
             }
               
       }
