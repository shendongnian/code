    [PersistChildren(true)]
    public partial class EventControl : UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            if (CustomContent != null)
            {
                CustomContent.InstantiateIn(PlaceHolderCustomContent);
            }
            base.OnInit(e);
        }
        public string ComponentLabel { get; set; }
        public string ComponentValue { get; set; }
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TemplateContainer(typeof(Irt.Web.ServerControls.PlaceHolder), System.ComponentModel.BindingDirection.TwoWay)]
        [TemplateInstance(TemplateInstance.Single)]
        [Browsable(false)]
        [Bindable(true, BindingDirection.TwoWay)]
        public ITemplate CustomContent
        { 
            get; 
            set; 
        }
    }
