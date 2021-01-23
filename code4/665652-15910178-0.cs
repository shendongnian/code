    class Project {
        int? ID { get; set; }
    }
    ...
    Comparison<Project> comparison = delegate(Project x, Project y)
    {
        int xkey = x.ID.HasValue ? x.ID.Value : int.MaxValue;
        int ykey = y.ID.HasValue ? y.ID.Value : int.MaxValue;
        return xkey.CompareTo(ykey);
    };
    list.Sort(comparison);
