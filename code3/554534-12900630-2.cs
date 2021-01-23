    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
      string _pName = Convert.ToString(GridView1.SelectedDataKey.Value); 
      // Once you get the pName you can query from DataTable and Delete the row which the pName = _pName
      // BindGrid and Store DataTable in session.
    }
