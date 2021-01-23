     public partial class WebUserControlChild : System.Web.UI.UserControl
    {
        public bool Checked
        {
            set
            {
                this.checkboxchild.Checked = value;
            }
            get{
                return this.checkboxchild.Checked;
            }
        }
        public string Text
        {
            set
            {
                this.labelchild.Text = value;
            }
            get{
                return this.labelchild.Text;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
