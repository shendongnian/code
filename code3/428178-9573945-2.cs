    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var bytes = (byte[])((DataRow)e.Row.DataItem)["roomImage1"];
            var base64String = System.Convert.ToBase64String(bytes, 0, bytes.Length);
            var image = (Image)e.Row.FindControl("pic1");
            image.ImageUrl = "data:image/gif;base64,"+ base64String;
            //or
            image.ImageUrl = "LinqHandler.ashx?roomID="+((DataRow)e.Row.DataItem)["roomID"];
        }
    }
