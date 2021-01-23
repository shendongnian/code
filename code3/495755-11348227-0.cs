    public partial class Test : System.Web.UI.UserControl
    {
        public string Value
        {
            get { return ddl1.SelectedValue; }
            set { ddl1.SelectedValue = value; }
        }
    }
