    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FindPanelControls(Page);
        }
    }
    private void FindPanelControls(Control ctrl)
    {
        if (ctrl.HasControls())
        {
            foreach (var childCtrl in ctrl.Controls.OfType<WebControl>())
            {
                //check for certain attributes
                if (childCtrl is Panel)
                    Response.Write(childCtrl.ID);
                //recursively call the function for this control
                FindPanelControls(childCtrl);
            }
        }
    }
