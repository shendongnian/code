    namespace My.Controls
    {
        /// <summary>
        /// Summary description for RolloverImageButton
        /// </summary>
        [DefaultProperty("Text")]
        [ToolboxData("<{0}:RolloverImageButton runat=server></{0}:RolloverImageButton>")]
        public class RolloverImageButton : ImageButton
        {
            [DefaultValue("")]
            [UrlProperty]
            [Bindable(true)]
            public virtual string ImageOverUrl
            {
                get
                {
                    if (null == ViewState["ImageOverUrl"]) return string.Empty;
                    else return Convert.ToString(ViewState["ImageOverUrl"]);
                }
                set { ViewState["ImageOverUrl"] = value; }
            }
    
            protected override void AddAttributesToRender(HtmlTextWriter writer)
            {
                writer.AddAttribute("onmouseover", "this.src='" + base.ResolveClientUrl(ImageOverUrl) + "'");
                writer.AddAttribute("onmouseout", "this.src='" + base.ResolveClientUrl(ImageUrl) + "'");
                base.AddAttributesToRender(writer);
            }
        }
    }
