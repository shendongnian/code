    public partial class DynamicControl : System.Web.UI.UserControl, IData
    {
        public string Name
        {
            get { return txtName.Text; }
        }
        
    
        public string Ship
        {
            get { return txtShip.Text; }
        }
        
    
        public DateTime StartTime
        {
            get { return Convert.ToDateTime(txtDate.Text); }
        }
    
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
    }
