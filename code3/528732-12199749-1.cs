    public enum Priority
    {
        Low,
        Medium,
        High
    }
    var orderedIssues = issues.OrderByDescending
                  (issue => (Priority)Enum.Parse(typeof(Priority), issue.Priority, true));
