    using Samples.AspNet.Session;
    // from inside a User Control or Page
    OdbcSessionStateStore.ResetItemTimeout2(this.Context, this.Session.SessionID);
    // --or--
    // from anywhere else
    OdbcSessionStateStore.ResetItemTimeout2(System.Web.HttpContext.Current, System.Web.HttpContext.Current.Session.SessionID);
