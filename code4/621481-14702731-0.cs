    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
         if (e.Row.RowType == DataControlRowType.DataRow)
         {
             string img = ((Image)e.Row.FindControl("Image1")).ImageUrl;
             string []ext=img.Split('.');
             if (ext.Length == 1)
             {
                 ((Image)e.Row.FindControl("Image1")).Visible = false;
             }
             else
             {
                 ((Image)e.Row.FindControl("Image1")).Visible = true;
             }
          }
         BindGrid();
    }
              
