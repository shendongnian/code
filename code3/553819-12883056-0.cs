      public partial class TestClick : System.Web.UI.Page
      {
        protected void Page_Load(object sender, EventArgs e)
        {
        if (!Page.IsPostBack) 
        {
            btnShowButtonText.Text = "Button";
            lblShowText.Visible = false;
        }
       }
    
    protected void btnShowButtonText_Click(object sender, EventArgs e)
    {
        if(hiddenField.Value == "0")
        {
           btnShowButtonText.Text = "Hide gift voucher details";
           lblShowText.Visible = true;
           hiddenField.Value = "1";
        }
        else
        {
           btnShowButtonText.Text = "Button";
           lblShowText.Visible = false;
           hiddenField.Value = "0";
        }
    }   
