    protected void Page_Load(object sender,EventArgs e)
    {
        if(Request["__EVENTTARGET"]=="radtree")
        {   
           var arguments = Request["__EVENTARGUMENT"]; // this will be "args"
           RadTreeView1_NodeClick(pass parameters);           
        }
    }
    protected void RadTreeView1_NodeClick(object sender,Telerik.Web.UI.RadTreeNodeEventArgs e)
    {
    }
