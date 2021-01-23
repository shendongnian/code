                    var project = db.Projects
                        .Include(i => i.ProjectFollower)
                        .Include(i => i.ProjectFollower.Select(v => v.User))
                        .Include(i => i.User)
                        .SingleOrDefault(i => i.ProjectID == project_id);
