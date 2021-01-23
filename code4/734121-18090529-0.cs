    public String CopyFolderContents(String sourceURL, String folderURL, String destinationURL)
    {
        try
        {
            #region Copying Code
            //Get the SPSite and SPWeb from the sourceURL
            using (SPWeb oWebsite = new SPSite(sourceURL).OpenWeb())
            {
                //Get the parent folder from the folderURL
                SPFolder oFolder = oWebsite.GetFolder(folderURL);
                //Create a list of all files (not folders) on the current level
                SPFileCollection collFile = oFolder.Files;
                //Copy all files on the current level to the target URL
                foreach (SPFile oFile in collFile)
                {
                    oFile.CopyTo(destinationURL + "/" + oFile.Name, true);
                }
                //Create a list of all folders on the current level
                SPFolderCollection collFolder = oFolder.SubFolders;
 
                //Copy each of the folders and all of their contents
                String[] folderURLs = new String[collFolder.Count];
                int i = 0;
                foreach (SPFolder subFolder in collFolder)
                {
                    folderURLs[i++] = subFolder.Url;
                }
                for (i = 0; i < folderURLs.Length; i++)
                {
                    SPFolder folder = collFolder[folderURLs[i]];
                    folder.CopyTo(destinationURL + "/" + folder.Name);
                }
            }
            #endregion Copying Code
        }
        catch (Exception e)
        {
            #region Exception Handling
            String Message;
            if (e.InnerException != null)
                Message =  "MESSAGE: " + e.Message + "\n\n" +
                       "INNER EXCEPTION: " + e.InnerException.Message + "\n\n" +
                       "STACK TRACE: " + e.StackTrace + "\n\n" +
                       "Source: " + sourceURL + "\n" + 
                       "Folder: " + folderURL + "\n" +
                       "Destination: " + destinationURL; 
            else
                Message =  "MESSAGE: " + e.Message + "\n\n" +
                       "STACK TRACE: " + e.StackTrace + "\n\n" +
                       "Source: " + sourceURL + "\n" +
                       "Folder: " + folderURL + "\n" +
                       "Destination: " + destinationURL;
            throw new Exception(Message);
            #endregion Exception Handling
        }
        return "Operation Successful!";
    }
