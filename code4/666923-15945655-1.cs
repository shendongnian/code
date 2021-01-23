    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<string> list = new List<string>()
                {
                    "item 1",
                    "item 2",
                    "item 3"
                };
                GridView1.DataSource = list;
                GridView1.DataBind();
            }
        
            // make sure outside of !IsPostback
            // recreate button every page load
            Button btn = new Button();
            btn.CommandName = "cmdSendMail";
            btn.CommandArgument = "sample arg";
            btn.Text = "send mail";
            GridView1.FooterRow.Cells[0].Controls.Add(btn);
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Response.Write(e.CommandName + new Random().Next().ToString());
        }
    }
  
