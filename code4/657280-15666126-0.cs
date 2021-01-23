    var notifications = from a in db.NotificationsLog
                        join p in db.Projects on a.ProjectId equals p.ProjectId
                        where a.CreatedBy == userID
                        select new NotificationModel
                                {
                                    id = a.id,
                                    ProjectId = p.ProjectId,
                                    ProjectName = p.ProjectName,
                                    Notes = a.Notes
                                };
