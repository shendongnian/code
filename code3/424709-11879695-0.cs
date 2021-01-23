    public void export2(DataTable dt) 
    {
        System.Web.UI.WebControls.DataGrid grid = 
                           new System.Web.UI.WebControls.DataGrid();
        grid.HeaderStyle.Font.Bold = true;
        grid.DataSource = dt;
        grid.DataBind();
        using (StreamWriter sw = new StreamWriter("C:\\Reports\\Report.xls"))
        {
            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            {
                **hw.Write("Employee Report");**
                **hw.Write("<br>");**
                grid.RenderControl(hw);                
            }
        }
    }
