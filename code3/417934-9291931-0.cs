    public TimeSpan GetTotalDuration()
    {
        if (SubTasks != null)
            return GetDuration() + SubTasks.Sum(t => t.GetTotalDuration()); 
        return GetDuration();
    }
