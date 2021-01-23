    / In a user control or page
    string sessionId = this.Session.SessionID; 
    
    // In a normal class, running in a asp.net app.
    string sessionId = System.Web.HttpContext.Current.Session.SessionID;
