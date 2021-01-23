    protected void Page_Load(object sender, EventArgs e)
    {
        gvAssignment.DataBound += new EventHandler(gvAssignment_DataBound);
    }
 
    void gvAssignment_DataBound(object sender, EventArgs e)
    {       
        gvAssignment.Columns[7].ItemStyle.Width = Unit.Pixel(100); 
    }   
