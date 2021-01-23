    var now = DateTime.Now;
    var query = _notificationsManager
        .GetUserNotifications(_repositoryNotifications, _memberShipProvider)
        .GroupBy(x => x.Category)
        .AsEnumerable() // Force local evaluation for final step
        .Select(g => new NotificationsGroupData {
          Name = g.Key,
          Notifications = g.Take(3)
                           .Select(s => new NotificationData {
                               Category = g.Key,
                               Text = s.Text,
                               Time = now - s.Time
                           })
        });
