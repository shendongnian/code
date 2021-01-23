    var workspace = pendingCheckin.GetWorkspace();
    var pendingChange = pendingCheckin.GetAllPendingChanges().FirstOrDefault();
    if(pendingChange != null) {
        return workspace.GetTeamProjectForLocalPath(pendingChange.LocalItem);
    }
