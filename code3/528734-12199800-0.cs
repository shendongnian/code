    public enum Priority
    {
        LOW = 1,
        MEDIUM = 2,
        HIGH = 3
    }
    issues.OrderByDescending(issue=>issue.Priority);
