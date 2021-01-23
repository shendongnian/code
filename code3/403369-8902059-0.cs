    var resultList = db.Projects.Where(z => !filterProjectId || z.ProjectId == MyProjectId).Select(p => new ProjectVM
    {
        ProjectId = p.ProjectId,
        ProjectName = p.ProjectName,
        TaskVM = p.Tasks.Where(t => !filterAssignedTo || t.AssignedTo == "John").OrderByDescending(t => t.TaskName).Select(t => new TaskVM
        {
            TaskId = t.TaskId,
            TaskName = t.TaskName,
            AssignedTo = t.AssignedTo
        })
    });
