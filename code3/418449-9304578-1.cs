    public DateTime FindTaskStartDate(Task task)
    {
        DateTime startDate = task.Start;
    
        foreach (var t in task.Tasks)
        {
            var subTaskDate = FindTaskStartDate(t);
            if (subTaskDate < startDate)
                startDate = subTaskDate;
        }
    
        return startDate;
    }
