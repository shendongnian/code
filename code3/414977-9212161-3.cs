    public partial class UserControl : System.Web.UI.UserControl {
        public string value {
            get { return ddl.SelectedValue.ToString(); }
        }
    }
