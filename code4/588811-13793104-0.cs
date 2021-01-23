    private void Page_Load(object sender, System.EventArgs e)
    {
        LoopDropDownLists(Page.Controls);
    }
    
    private void LoopDropDownLists(ControlCollection controlCollection)
    {
        foreach(Control control in controlCollection)
        {
            if(control is DropDownList)
            {
                ((DropDownList)control).DataSource = //Set datasource here!
            }
    
            if(control.Controls != null)
            {
                LoopDropDownLists(control.Controls);
            }
        }
    }
