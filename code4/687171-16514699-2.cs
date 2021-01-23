    var sub = DetachedCriteria
      .For<UserTask>()
      // WHERE 
      .Add(Restrictions.In("UserId", new int[] { 1, 2 })) // example of filtering 'user_id'
      .Add(Restrictions.Eq("solved", true))               // 'solved'
      .SetProjection(Projections.Property("TaskId")); // TaskId the SELECT clause
