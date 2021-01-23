    //divMain should be a reference to the 'items' div...
    
    int i = 0;
    
    System.Web.UI.HtmlControls.HtmlGenericControl divCurrent = 
        new System.Web.UI.HtmlControls.HtmlGenericControl("div");
    
    
    foreach (string imgSrc in imgSrcs)
    {
        Image img = new Image();
        img.ImageUrl = imgSrc;
        divCurrent.Controls.Add(img);
        if (i++ ==5) {
            divMain.Controls.Add(divCurrent);
            divCurrent = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
            i = 0;
        }
    }
