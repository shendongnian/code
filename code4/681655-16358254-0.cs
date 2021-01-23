    var groupIds = context.Set<UserControl>()
                      .Where(x => x.SystemUserId ==System.Convert.ToInt32(userId))
                      .Select(x => x.SystemGroupId);
                      .ToList();
    var userGroups = context.Set<Group()
                            .Where(g=>groupIds.Contains(g.GroupId)).ToList();
