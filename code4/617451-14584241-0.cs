    // Observable collection is the best choice to bind to the UI elements it automatically refreshes the changes in the UT whenever the data modifies. 
    
        ObservableCollection<string> objList = new ObservableCollection<string>();
        
              //Bind this ObservableCollection to the UI Element with TwoWay binding
        
              var rootDirFile = Directory.EnumerateFiles(pathToSearch, "*.pcap", SearchOption.TopDirectoryOnly).OrderByDescending(f => File.GetCreationTime(f)).Take(1);
               // add to the observable collection
        
              var allNewestFilesOfEachFolder = Directory
                            .EnumerateDirectories(pathToSearch, "*.*", SearchOption.AllDirectories);
        
               // Instead of Iterating the Directory in a single time, seperate the task and iterate folder by folder basis.
        
                foreach (string obj  in allNewestFilesOfEachFolder )
        		{
                    var dir = Directory
                            .EnumerateFiles(obj, "*.pcap", SearchOption.TopDirectoryOnly)
                            .OrderByDescending(f => File.GetCreationTime(f))
                            .Take(1);    
        
                    // add to the observable collection , it will automatically reflects the changes in the UI            
           
        		}
