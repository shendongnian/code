    var parents = context.Parents.ToList();
    foreach(var parent in parents)
    {
        var invalidChildren = parent.CHILD
            .Where(child => child.CONCLUSION.HasValue())
            .ToArray();
        foreach(var invalid in invalidChildren)
        {
            parent.CHILD.Remove(invalid);
        }
    }
