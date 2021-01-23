    public string RenameFolder(string name, string folderid)
        {
            Outlook.Application app = new Outlook.Application();
            Outlook.NameSpace ns = null;
            Outlook.Folder folder = null;
            string n= null;
            try
            {
                ns = app.GetNamespace("MAPI");
                folder = ns.GetFolderFromID(folderid) as Outlook.Folder;
                n=folder.Name;
                folder.Name = (folder.Name = name) ;
                return n + " has been successfully changed to " + folder.Name;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (app != null)
                {
                    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(app);
                }
                if (folder != null)
                {
                    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(folder);
                }
                if (ns != null)
                {
                    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(ns);
                }
            }
        }
    
