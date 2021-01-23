    Image ThumbImg = new Image();
    ThumbImg.ImageUrl = ImgUrl; 
    HtmlGenericControl divContent = new HtmlGenericControl("div");
    divContent.Controls.Add(ThumbImg);
    LiteralControl lit = new LiteralControl();
    lit.Text = Desc;
    divContent.Controls.Add(lit);
