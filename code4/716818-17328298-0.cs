    var query = context.Projects.Where(project => 
            project.Tasks.Any(task => task.Status == someStatus)
        .Select(project => new
        {
            project.ProjectName,
            Tasks = project.Tasks.Where(task => task.Status == someStatus),
        });
