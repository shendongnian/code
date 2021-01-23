    var dbProjects = yourContext.Projects
                        .Include(p => p.ProjectComments
                                  .OrderByDescending(pc => pc.CreatedOn)
                                  .Select(pc => pc.Comments)
                                  .FirstOrDefault()
                                )
                        .Include(p => p.ProjectFileIDs)
                        .AsQueryable<Models.Project>();
