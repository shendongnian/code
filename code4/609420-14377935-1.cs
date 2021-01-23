    protected void grvYoutubeVideo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl = (Label)e.Row.Cells[0].Controls[1];
    
            if (lbl.Text != "")
            {
                    //string YTVideoURL = lbl.Text;    //"http://www.youtube.com/v/AyPzM5WK8ys";
                    //string OBJYTVideo = "<object width=\"150\" height=\"150\">";
                    //OBJYTVideo += "<param name=\"movie\" value=\"" + YTVideoURL + "\"></param>";
                    //OBJYTVideo += "<param name=\"allowscriptaccess\" value=\"always\"></param>";
                    //OBJYTVideo += "<embed src=\"" + YTVideoURL + "\" type=\"application/x-shockwave-flash\"";
                    //OBJYTVideo += "allowscriptaccess=\"always\" width=\"100%\" height=\"100%\"></embed></object>";
                    //lbl.Text = OBJYTVideo;
            }
        }
    }
