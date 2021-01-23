     public static Folder FOLDER_1;
     public static Folder FOLDER_2;
     public static Folder FOLDER_N;
    
    /// <summary>
            /// Hilo que lee el archivo de datos PST del OUTLOOK
           private static void readPst()
            {
                try
                {
                    Application app = new Application();
                    NameSpace outlookNs = app.GetNamespace("MAPI");
                    MAPIFolder mf = outlookNs.GetDefaultFolder(OlDefaultFolders.olFolderTasks);
    
    
                    string names = mf.FolderPath.Split('\\')[2];
                   
    
    
                    Folder fMails = getFolder(fCarpetasPersonales.Folders, "Inbox");
    
    
                   
                    FOLDER_1= getFolder(fMails.Folders, "FOLDER_1");
                    FOLDER_2= getFolder(fMails.Folders, "FOLDER_2");
                    FOLDER_N= getFolder(fMails.Folders, "FOLDER_n");
        
    //TO DO... For example:  foreach (object item in fMails.Items)
                               
    
    
         private static Folder getFolder(Folders folders, string folder)
            {
                foreach (object item in folders)
                {
                    if (item is Folder)
                    {
                        Folder f = (Folder)item;
                        if (f.Name.Equals(folder))
                        {
                            return f;
                        }
                    }
                }
                return null;
            }    
            
