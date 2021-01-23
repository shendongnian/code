    IQueryable<Project> projects = unitOfWork.ProjectRepository.Get(filter);
    if(showArchived)
    {
        projects = projects.Where(p => p.Archived);
    }
