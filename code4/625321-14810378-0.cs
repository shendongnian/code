    DateTime startThisWeek = DateFunctions.GetFirstDayOfWeek(DateTime.Now.Date).AddDays(1);
    DateTime endOfThisWeek = startThisWeek.AddDays(6);
    DateTime today = DateTime.Now.Date;
    DateTime yesterday = DateTime.Now.Date.AddDays(-1);
    var notificationList = 
    (from n in db.DashboardNotifications
                 .OrderByDescending(n => n.NotificationDateTime)
     where (n.NotificationDateTime >= startThisWeek && 
            n.NotificationDateTime.Date <= endOfThisWeek) &&  
           (n.NotificationDateTime.Date != today && 
            n.NotificationDateTime.Date != yesterday)
     select n).ToList();
