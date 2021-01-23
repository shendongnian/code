    [
    AspNetHostingPermission(SecurityAction.Demand,
        Level = AspNetHostingPermissionLevel.Minimal),
    AspNetHostingPermission(SecurityAction.InheritanceDemand,
        Level = AspNetHostingPermissionLevel.Minimal),
    DefaultProperty("Items"),
    ParseChildren(true, "Items"),
    ToolboxData("<{0}:SideBar runat=\"server\"> </{0}:SideBar>")
    ]
    public class SideBar : WebControl
    {
        private ArrayList itemsList;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        //[Editor(typeof(ContactCollectionEditor), typeof(UITypeEditor))]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        public ArrayList Items
        {
            get
            {
                if (itemsList == null)
                {
                    itemsList = new ArrayList();
                }
                return itemsList;
            }
        }
        protected override void RenderContents(HtmlTextWriter writer)
        {
            writer.RenderBeginTag(HtmlTextWriterTag.Ul);
            foreach (object o in itemsList)
            {
                SideBarItem item = (SideBarItem)o;
                writer.RenderBeginTag(HtmlTextWriterTag.Li);
                writer.AddAttribute(HtmlTextWriterAttribute.Href, item.NavigateUrl);
                writer.RenderBeginTag(HtmlTextWriterTag.A);
                writer.AddAttribute(HtmlTextWriterAttribute.Src, item.ImageUrl);
                writer.RenderBeginTag(HtmlTextWriterTag.Img);
                writer.RenderEndTag(); // Img
                writer.RenderEndTag(); // A
                writer.RenderEndTag(); // Li
            }
            writer.RenderEndTag(); // Ul
        }
    }
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class SideBarItem
    {
        public SideBarItem()
            : this(String.Empty, String.Empty, String.Empty)
        {
        }
        public SideBarItem(string imgUrl, string navUrl, string label)
        {
            ImageUrl = imgUrl;
            NavigateUrl = navUrl;
            Label = label;
        }
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        public String ImageUrl { get; set; }
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        public String NavigateUrl { get; set; }
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        public String Label { get; set; }
    }
