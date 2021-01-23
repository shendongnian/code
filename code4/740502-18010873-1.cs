    public partial class dockPanel :System.Web.UI.UserControl, INamingContainer
    {
    
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TemplateContainer(typeof(dockPanel))]
        public ITemplate ContentTemplate { get; set; }
    
         protected override void OnInit(EventArgs e)
            {
                base.OnInit(e);
                
                if (ContentTemplate != null)
                    ContentTemplate.InstantiateIn(this);
            }
    }
