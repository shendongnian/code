    public override void RenderBeginTag(System.Web.UI.HtmlTextWriter writer)
    {
        writer.Write(String.Format("<div id=\"{0}\" class=\"{1}\">",
                                   this.ClientID,this.CssClass));
    }
