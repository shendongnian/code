    [ToolboxData("<{0}:TabContainer runat=server></{0}:TabContainer>")]
    [ParseChildren(ChildrenAsProperties = false)]
    [PersistChildren(true)]
    public class TabContainer : Panel, INamingContainer
    {
        List<TabItem> tabs = new List<TabItem>();
        [Browsable(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public List<TabItem> Tabs
        {
            get { return this.tabs; }
        }
    }
    public class TabItem : Panel, IPostBackEventHandler
    {
        public event EventHandler Click;
    }
