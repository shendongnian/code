    public static void OnNotificationChange(object caller, SqlNotificationEventArgs e)
    {
        if (e.Type == SqlNotificationType.Change && (e.Info == SqlNotificationInfo.Insert || e.Info == SqlNotificationInfo.Delete || e.Info == SqlNotificationInfo.Update))
        {
            SqlDependency dependency =(SqlDependency)sender;
            dependency.OnChange -= OnNotificationChange;
            RegisterForChanges();
        }
    }
