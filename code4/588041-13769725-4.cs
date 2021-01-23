    public partial class AddQuestions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
                ViewState["Num"] = "1";
        }
        protected void ASPxButton1_Click(object sender, EventArgs e)
        {           
            QnoTextBox.Text = ViewState["Num"].ToString();
            int num = int.Parse(ViewState["Num"].ToString());
            ViewState["Num"] = num++;
        }
    }
