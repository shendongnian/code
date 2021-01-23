    protected override void OnInit(EventArgs e)
    {
      grid1.RowDataBound += grid1_RowDataBound;
    }
    
    void grid1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      var grid2 = (GridView)e.Item.FindControl("grid2");
      grid2.DataSource = StudentList.Where(w => w.Name = (e.Item.DataItem as Student).Name);
      grid2.Bind();
    }
