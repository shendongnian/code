    public enum Permissions 
    {   
        DeleteNoWriteNoReadNo = 0,   // None
        DeleteNoWriteNoReadYes = 1,  // Read
        DeleteNoWriteYesReadNo = 2,  // Write
        DeleteNoWriteYesReadYes = 3, // Read + Write
        DeleteYesWriteNoReadNo = 4,   // Delete
        DeleteYesWriteNoReadYes = 5,  // Read + Delete
        DeleteYesWriteYesReadNo = 6,  // Write + Delete
        DeleteYesWriteYesReadYes = 7, // Read + Write + Delete
    } 
