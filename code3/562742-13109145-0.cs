    private List<string> GetAllFolders()
    {
       var allFolders = new List<string>();
       return GetAllFolders(this.sourceFolder);  
    }
    
    // recursively list all folders, catch and continue in case of errors
    private List<string> GetAllFolders(string folder)
    {
         DirectoryInfo directoryInfo = new DirectoryInfo(folder);
         List<string> allFolders = new List<string>();
    
         foreach (DirectoryInfo subDirectoryInfo in directoryInfo.GetDirectories())
         {
              //logic
             try {
               allFolders.Add(subDirectoryInfo.FullName);
              allFolders.AddRange(GetAllFolders(subDirectoryInfo.FullName));
            }
            catch (Exception exp)
            {
              // log rrors
              Debug.WriteLine(" exception for " + 
                                  subDirectoryInfo.FullName + " : " + 
                                exp.Message);
                    } 
                }
                return allFolders;
            }
