    [ToolboxData("<{0}:TabContainer runat=server></{0}:TabContainer>")]
    [ParseChildren(ChildrenAsProperties = false)]
    [PersistChildren(true)]
    public class TabContainer : Panel, INamingContainer
    {
        #region private properties
        List<TabItem> tabs = new List<TabItem>();
        #endregion
        [Bindable(true)]
        public event EventHandler TabClick;
        [Browsable(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public List<TabItem> Tabs
        {
            get { return this.tabs; }
        }
    }
