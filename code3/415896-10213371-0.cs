    if(subDirs.Lenght != 0)        // or > 0
    {
      string pathToSubFolders = Path.Combine(dirInfo.ToString(), subDirs[0].ToString());
      PopulateTreeView(treeView1, pathToSubFolders);
    }
    else
    {
      //Do Something Here
    }
