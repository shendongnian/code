    SPFolder subFolder = list.RootFolder.SubFolder[i];
    SPFolderCollection subFoldersOfSubFolder = subFolder.SubFolders;
    if (subFoldersOfSubFolder.Count > 0)
    {
        for (int j = 0; j < subFoldersOfSubFolder.Count; j++)
        {
            SPFolder specificSubFolder = subFoldersOfSubFolder[j];
            /*
                At this point you could use properties like Name, 
                ServerRelativeUrl or UniqueId of the SubFolder class to get 
                the information you need.
            */
        }
    }
    else
    {
        //If you get to here, it means that the sub-folder had no sub-folders
    }
