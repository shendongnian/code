    protected void RadGrid1_PreRender(object sender, EventArgs e)
    {
      GridColumn gridCol = RadGrid1.MasterTableView.GetColumn("columnname");
      gridCol.HeaderStyle.Width = Unit.Pixel(100);   
    }
