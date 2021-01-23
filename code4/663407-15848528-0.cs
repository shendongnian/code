    _notificationsManager
        .GetUserNotifications(_repositoryNotifications, _memberShipProvider)
        .GroupBy(x => x.Category)
        .ToList()
        .Select(g => new NotificationsGroupData {
              Name = g.Key,
              Notifications = g.Take(3).Select(s => new NotificationData  {
                                               Category = g.Key,
                                               Text = s.Text,
                                               Time = DateTime.Now.Subtract(s.Time)
                                             })
         })
