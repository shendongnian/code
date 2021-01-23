     public static void SetFileReadAccess(string FileName, bool SetReadOnly)
     {
          FileInfo fInfo = new FileInfo(FileName);
    
          // Set the IsReadOnly property.
          fInfo.IsReadOnly = SetReadOnly;
    
     }
