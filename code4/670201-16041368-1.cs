    List<DA.GeneralRequest> ongoingGeneralRequests = db.GeneralRequests
          .Where(t => t.GeneralRequestStatusID != 3 && (t.SupervisorID == currentUserId || t.CreatorID == currentUserId || t.AssignedUsers.Any(au => au.UserID == currentUserId)))
          .Select(x => new {
                        Value = x, 
                        OrderByValue = x.GeneralRequestActivities
                                 .OrderBy(ga => ga.GeneralRequestActivityDate)
                                 .LastOrDefault()) // cache value
          .OrderByDescending(x => x.OrderByValue != null ? 
                                      OrderByValue.GeneralRequestActivityDate 
                                    : some default value)
          .ThenBy(a => a.Value.Deadline)
          .Select(a => a.Value)
          .ToList();
