    HtmlLink link = new HtmlLink();
    //Add appropriate attributes
    link.Attributes.Add("rel", "stylesheet");
    link.Attributes.Add("type", "text/css");
    link.Href = "/Resources/CSS/NewStyles.css";
    link.Attributes.Add("media", "screen, projection");
    //add it to page head section
    this.Page.Header.Controls.Add(link);
