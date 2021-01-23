    List<string> _OrderIds = new List<string>();
      
      DataTable table = gvOrderLines.DataSource as DataTable;
    
      foreach (GridViewRow gvr in table.Rows)
      {
        Label myOrderIDLablel = (Label)gvr.FindControl("lblOrderID");    //find control since it is a template field
        _OrderIds.Add(myOrderIDLablel.Text);
      }
