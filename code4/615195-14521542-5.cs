    public partial class CustomUC : System.Web.UI.UserControl
    {
        //Enables the Option properties to be filled inside the control's tag
        [PersistenceMode(PersistenceMode.InnerProperty)] 
        //Enables the Option properties to be filled on the control's tag
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Option Options
        {
            get;set;
        }
        protected void Page_Load(object sender, EventArgs e) { }
    }
