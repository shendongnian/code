    var notifications = 
        (from a in db.NotificationsLog
         let p = a.Project
         where a.CreatedBy == userID
         orderby a.CreatedDateTime ascending
         select new NotificationModel
         {
             id = a.id,
             ProjectId = p.Id,
             ProjectName = p.Name,
             Project = new ProjectModel
             {
                 ProjectId = p.Id
                 ProjectName = p.Name
                 Notes = a.Notes;
             }
         });
