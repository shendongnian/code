    public User[] GetUsers(int[] activityIds, int[] trainingIds)
    {
        return _context.Users
            .Where(u => u.Activities.Any(a => activityIds.Contains(a.Id)) ||
                        u.Training.Any(t => trainingIds.Contains(t.Id)))
            .ToArray();
    }
