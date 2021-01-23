     protected void gridView1_RowDataBound(Object sender, GridViewRowEventArgs args)
        {
         if(args.Row.RowType == DataControlRowType.DataRow)
         {
          Image img = (Image) e.Row.FindControl("Image1");
          img.ImageUrl = setImageURLHere;
         }
        }
