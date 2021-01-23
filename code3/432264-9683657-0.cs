    Expression<Func<Project, bool>> filter = (Project p) => p.UserName == "Bob";
    if(showArchived) {
         filter = (Project p) => p.UserName == "Bob" && p.Archived;
    }
    IEnumerable<Project> projects = unitOfWork.ProjectRepository.Get(filter);
