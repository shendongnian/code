     if (GridView1.PageIndex == 0)
      {
         GridView1.Rows[0].FindControl("lnkUp").Visible = false;
    
      }
      if (GridView1.PageIndex == (GridView1.PageCount - 1))
      {
          GridView1.Rows[GridView1.Rows.Count - 1].FindControl("lnkDown").Visible = false;
      }
