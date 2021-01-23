    /* Some temporary directory to download the latest versions to, for comparing. */
    String tempDir = @"C:\Temp\TFSLatestVersion";
    /* Load the workspace information from the local workspace cache */
    WorkspaceInfo workspaceInfo = Workstation.Current.GetLocalWorkspaceInfo(folderPath);
    /* Connect to the server */
    TfsTeamProjectCollection projectCollection = new TfsTeamProjectCollection(WorkspaceInfo.ServerUri);
    VersionControlServer vc = projectCollection.GetService<VersionControlServer>();
    /* "Realize" the cached workspace - open the workspace based on the cached information */
    Workspace workspace = vc.GetWorkspace(workspaceInfo);
    /* Get the server path for the corresponding local items */
    String folderServerPath = workspace.GetServerItemForLocalItem(folderPath);
    /* Query all items that exist under the server path */
    ItemSet items = vc.QueryItems(new ItemSpec(folderServerPath, RecursionType.Full),
        VersionSpec.Latest,
        DeletedState.NonDeleted,
        ItemType.Any,
        true);
    foreach(Item item in items.Items)
    {
        /* Figure out the item path relative to the folder we're looking at */
        String relativePath = item.ServerItem.Substring(folderServerPath.Length);
        /* Append the relative path to our folder's local path */
        String downloadPath = Path.Combine(folderPath, relativePath);
        /* Create the directory if necessary */
        String downloadParent = Directory.GetParent(downloadPath).FullName;
        if(! Directory.Exists(downloadParent))
        {
            Directory.CreateDirectory(downloadParent);
        }
        /* Download the item to the local folder */
        item.DownloadFile(downloadPath);
    }
    /* Launch your compare tool between folderPath and tempDir */
