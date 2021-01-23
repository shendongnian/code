    var resultList = query.Where(assignedToFilter).Select(p => new ProjectVM
    {
        ProjectId = p.ProjectId,
        ProjectName = p.ProjectName,
        TaskVM = p.Tasks
            .Where(assignedToFilter)
            .OrderByDescending(t => t.TaskName)
            .Select(t => new TaskVM
            {
                TaskId = t.TaskId,
                TaskName = t.TaskName,
                AssignedTo = t.AssignedTo
            })
    });
