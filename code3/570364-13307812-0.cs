    public partial class ControlFormulaire : System.Web.UI.UserControl
    {
        public event EventHandler ButtonClicked;// it could be named differently obviously
        protected void ValidateButton_Click(object sender, EventArgs e)
        {
               ButtonClicked();
        }
    
        private void ButtonClicked()
        {
           if (ButtonClicked!= null)
           {
               ButtonClicked(this, EventArgs.Empty);
           }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
**************
    protected void Page_Load(object sender, EventArgs e)
    {
        ControlFormulaire.ButtonClicked+= new EventHandler(SubscribForm_ButtonClicked);
    }
    
    void SubscribForm_ButtonClicked(object sender, EventArgs e)
    {
        Response.Redirect("WebForm2.aspx");
    }
