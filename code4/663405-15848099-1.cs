    // Use a single common idea of "now", don't re-evaluate each time
    var now = DateTime.Now;
    var query = _notificationsManager
        .GetUserNotifications(_repositoryNotifications, _memberShipProvider)
        .GroupBy(x => x.Category)
        .Select(g => new {
          Name = g.Key,
          Notifications = g.Take(3)
                           .Select(s => new {
                               Text = s.Text,
                               Time = s.Time
                           })
        })
        .AsEnumerable() // Force local evaluation for final step
        .Select(g => new NotificationsGroupData {
          Name = g.Name,
          Notifications = g.Notifications
                           .Select(s => new NotificationData {
                               Category = g.Name,
                               Text = s.Text,
                               Time = now - s.Time
                           })
        });
