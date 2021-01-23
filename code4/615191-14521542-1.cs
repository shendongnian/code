    public partial class CustomUC : System.Web.UI.UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Option Options
        {
            get;set;
        }
        protected void Page_Load(object sender, EventArgs e) { }
    }
