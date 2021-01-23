    public ReturnClass FindSubFiles(String Folder_To_Search , 
                                    String User, String SessionId )
    {
        ReturnClass myReturnClass = new ReturnClass(-1, String.Empty, String.Empty, 
                                                   null, null, null, null);
        try
        {
            Logging.Write_To_Log_File("Entry", MethodBase.GetCurrentMethod().Name, 
                                      "", "", "", "", User, SessionId, 1);
            string[] filePaths = Directory.GetFiles(Folder_To_Search + "\\");
            int count = 0;
            foreach (string Folder in filePaths)
            {
                filePaths[count] = Path.GetFileName(filePaths[count]);
                count++;
            }
            myReturnClass.ErrorCode = 1;
            myReturnClass.FilePaths = filePaths;
            Logging.Write_To_Log_File("Exit", MethodBase.GetCurrentMethod().Name, 
                                      "", "", "", "", User, SessionId, 1);
            return myReturnClass;
        }
        catch (Exception ex) 
        {
            Logging.Write_To_Log_File("Error", MethodBase.GetCurrentMethod().Name, 
                                      "", "", ex.ToString(), "", User, SessionId, 2);
            myReturnClass.ErrorCode = -1;
            myReturnClass.ErrorMessage = ex.ToString();
            return myReturnClass;
        }
    }
