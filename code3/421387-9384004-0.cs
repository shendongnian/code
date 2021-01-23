    ImageRepeater.ItemDataBound += new RepeaterItemEventHandler(ImageRepeater_ItemDataBound);
    
    private void ImageRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
    	[File] f = (File)e.Item.DataItem;
        HyperLink ImageHyperLink = (HyperLink)e.Item.FindControl("ImageHyperLink");
        string str = f.ImageUrl;
        ImageHyperLink.NavigateUrl = "default.aspx?name=" + Server.UrlEncode(str);
    }
