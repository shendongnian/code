    public static void LogStockPageView(int stockId)
    {
        DataContext dataContext = HttpContext.Current.Items["DataContext"] as DataContext;
    
        WebsiteUserSession websiteUserSession = GetWebsiteUserSession();
    
        dataContext.WebsiteUserSessions.Attach(websiteUserSession);
    
        WebsitePageTracking pageTrack = new WebsitePageTracking();
        pageTrack.DateTime = DateTime.Now;
        pageTrack.TrackUrl = HttpContext.Current.Request.Url.ToString();
    
        dataContext.WebsitePageTracking.Add(pageTrack);
    
        // Make connection after both session and track are correctly configured and attached
        pageTrack.WebsiteUserSession = websiteUserSession;
    
        dataContext.SaveChanges();
    
        // again detach session 
        dataContext.Entry(websiteUserSession).State = EntityState.Detached;
    }
