    int[] users = new int[] {1,3};  // for testing
    database.Ustr_Tags.Where(t => users.Contains(t.User_id))
                      .GroupBy(t => t.Tag_id)
                      .Where(g => users.All(u => g.Any(gg=>gg.User_id == u)))  // all tags where all required users are tagged
                      .Select(g => g.Key);
