    foreach (var item in body3)
    {
        db.RunInTransaction(() =>
        {
            db.Insert(new Site
            {
                siteName = item.siteName,
                siteAddress = item.siteAddress,
                siteCity = item.siteCity,
                siteState = item.siteState,
                siteID = item.siteID
            });
        });
        await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
        {
            progressBar.Value = i;                                
            i++;
        });
    }
