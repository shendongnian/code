    public bool CheckIfFileIsBeingUsed(string fileName){
    
         try{    
             File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.None);
              }
    
          catch (Exception exp){
                   return true;
            }
    
          return false;
