    ContentPlaceHolder blar = (ContentPlaceHolder)Master.FindControl("HeadContent");
    HtmlLink css= new HtmlLink();
    css.Attributes.Add("rel", "stylesheet");
    css.Attributes.Add("type", "text/css");
    css.Href = "/Styles/site.css";
    blar.Controls.Add(css); 
    
