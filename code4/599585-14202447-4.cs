public abstract class LoggingPage : System.Web.UI.Page
{
    protected override void RaisePostBackEvent(
        IPostBackEventHandler sourceControl, string eventArgument)
    {
        //doing something with the information.
        EventLog.WriteEntry("Page event for " + sourceControl.UniqueID + " at " + this.Request.Url);
        //then call the base implementation
        base.RaisePostBackEvent(sourceControl, eventArgument);
    }
}
