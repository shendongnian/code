    var auc = new AutomaticUpdatesClass();
    DateTime? lastInstallationSuccessDateUtc = null;
    if (auc.Results.LastInstallationSuccessDate is DateTime)
        lastInstallationSuccessDateUtc = new DateTime(((DateTime)auc.Results.LastInstallationSuccessDate).Ticks, DateTimeKind.Utc);
     DateTime? lastSearchSuccessDateUtc = null;
     if (auc.Results.LastSearchSuccessDate is DateTime)
         lastSearchSuccessDateUtc = new DateTime(((DateTime)auc.Results.LastSearchSuccessDate).Ticks, DateTimeKind.Utc);
