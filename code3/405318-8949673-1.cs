    if(Session
        .Query<Project>()
        .Where(p=>p.ID == projectID && p.ProjectOwner.Responsible == CurrentUserID)
        .Select(p=>new { pID = p.ID })
        .Any())
    {
       ...
    }
