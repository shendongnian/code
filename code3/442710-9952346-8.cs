    public void DeleteGroup5(KeyValuePair<int, string> groupToDelete)
    {
        (
            from g in Groups
            where g.Key == groupToDelete.Key
            select g
        ).ToList().ForEach(g => Groups.Remove(g));
    }
