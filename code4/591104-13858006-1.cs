    public partial class home : System.Web.UI.Page
    {
        private void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                // initialise list
                ViewState["Messages"] = new List<string>();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            // get the old messages list
            var messages = (List<string>)ViewState["Messages"];
            messages.Add(text1.Text);
            ListBox1.DataSource = messages;
            ListBox1.DataBind();
            // store the new messages list
            ViewState["Messages"] = messages;
        }   
    }
