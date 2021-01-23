    Analytics.AnalyticsManager manager = new Analytics.AnalyticsManager(Server.MapPath("~/bin/privatekey.p12"), "YOUR_EMAIL");
                manager.LoadAnalyticsProfiles();
    
    
    List<Analytics.Data.DataItem> metrics = new List<Analytics.Data.DataItem>();
    metrics.Add(Analytics.Data.Visitor.Metrics.visitors);
    metrics.Add(Analytics.Data.Session.Metrics.visits);
    List<Analytics.Data.DataItem> dimensions = new List<Analytics.Data.DataItem>();
    dimensions.Add(Analytics.Data.GeoNetwork.Dimensions.country);
    dimensions.Add(Analytics.Data.GeoNetwork.Dimensions.city);
    
                
    System.Data.DataTable table = manager.GetGaDataTable(DateTime.Today.AddDays(-3), DateTime.Today, metrics, dimensions, null, metrics);
