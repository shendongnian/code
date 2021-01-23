    public List<Task> GetTasks(int empId) 
    {
        return tTask
            .Where(t => tTaskView.Where(v => v.ID == empId).Select(v => v.TaskId).Contains(t.ID))
            .Select(t => new Task() 
            { 
                ID = t.ID, 
                ActionableID = t.ActionableID, 
                StatusID = t.StatusID, 
                TypeID = t.TypeID, 
                Description = t.Description 
            }).ToList();
    }
