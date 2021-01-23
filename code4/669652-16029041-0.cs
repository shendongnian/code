    protected void RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            //find your cell suppose it is Cell 0
           string imgUrl=e.Row.Cells[0].Text;
           Image img = new Imge();
           img.Imageurl=imgUrl;
           e.Row.Cells[0].Controls.Add(img);
            
        }
    }
