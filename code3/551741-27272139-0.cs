    responsibleUser = responsibleUser == null ? null : db.User.Find(responsibleUser.UserId);
    if (responsibleUser == null)
    {
        // load the value to assure setting it to null will cause a change
        var dummy = project.ResponsibleUser; 
    }
    project.ResponsibleUser = responsibleUser;
    ...
    db.SaveChanges();
