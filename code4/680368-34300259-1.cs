    // using WUApiLib;
    AutomaticUpdates auc = new AutomaticUpdates();
    auc.Settings.NotificationLevel = AutomaticUpdatesNotificationLevel.aunlNotifyBeforeInstallation;
    if (!auc.Settings.ReadOnly)
        auc.Settings.Save();
