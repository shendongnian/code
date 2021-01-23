    public partial class Sample : System.Web.UI.UserControl
    {
        public Button SubmitButton
        { get { return this.btnSubmit; } set { this.btnSubmit = value; } }
    
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
    
    
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //Do Something
        }
    }
