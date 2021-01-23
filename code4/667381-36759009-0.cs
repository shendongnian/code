    private static Workspace FindWorkspaceByPath(TfsTeamProjectCollection tfs, string workspacePath)
    { 
    	VersionControlServer versionControl = tfs.GetService<VersionControlServer>();
    
    	WorkspaceInfo workspaceInfo = Workstation.Current.GetLocalWorkspaceInfo(workspacePath);
    
    	if (workspaceInfo != null)
    	{
    		return versionControl.GetWorkspace(workspaceInfo);
    	}
    
    	// No Workspace found using method 1, try to query all workspaces the user has on this machine.
    	Workspace[] workspaces = versionControl.QueryWorkspaces(null, Environment.UserName, Environment.MachineName);
    	foreach (Workspace w in workspaces)
    	{
    		foreach (WorkingFolder f in w.Folders)
    		{
    			if (f.LocalItem.Equals(workspacePath))
    			{
    				return w;
    			}
    		}
    	}
    
    	throw new Exception(String.Format("TFS Workspace cannot be determined for {0}.", workspacePath));
    }
