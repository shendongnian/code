    public partial class UC1 : System.Web.UI.UserControl
    {
        public IExport MyExport { get; set; }
    
        protected void Page_Load(object sender, EventArgs e)
        {
            MyExport.Export();
        }
    }
