    using System.Web.Services;
    [WebMethod]
    public static void UpdateListsInSessionCache(List<ListItem> source, List<ListItem> target)
    {
        Session["SourceList"] = source;
        Session["TargetList"] = target;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        // Create new lists so we have something empty and not null to work with
        var source = new List<ListItem>();
        var target = new List<ListItem>();
        // Always check for values in Session cache and update if there are values
        if (Session["SourceList"] != null)
        {
            source = Session["SourceList"] as List<ListItem>;
        }
        if (Session["TargetList"] != null)
        {
            target = Session["TargetList"] as List<ListItem>;
        }
        // Do something with source and target lists
    }
