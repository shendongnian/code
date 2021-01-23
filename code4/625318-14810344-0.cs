    DateTime startThisWeek = DateFunctions.GetFirstDayOfWeek(DateTime.Now);
    DateTime yesterday  = DateTime.Today.AddDays(-1);
    
    var notificationList = 
       (from n in db.DashboardNotifications
        where n.NotificationDateTime.Date >= startThisWeek.Date && 
              n.NotificationDateTime.Date < yesterday)
        orderby n.NotificationDateTime descending
        select n).ToList();
