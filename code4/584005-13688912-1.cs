    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        //Generate fake data
        var data = Enumerable.Range(1, 20);
        //Give the data to the grid
        gvGrid.DataSource = data;
        gvGrid.DataBind();
      }
    }
    protected void gvGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        //Find the control
        var lblTotal = (Label)e.Row.FindControl("lblTotal");
        //Get the data for this row
        var data = (int)e.Row.DataItem;
        //Display the data
        lblTotal.Text = data.ToString();
      }
    }
