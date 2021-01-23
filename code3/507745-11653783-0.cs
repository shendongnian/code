    namespace HelpSO3
    {
        public partial class _Default : System.Web.UI.Page
        {
            List<string> t = new List<string>();
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack)
                {
                    string s = "hi";
                    t.Add(s);
                    GridView1.DataSource = t;
                    GridView1.DataBind();
                    Session["MyList"] = t;
                }
            }
    
            protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
            {
              
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                t = (List<string>)Session["MyList"];
                t.Add("Another String");
                GridView1.DataSource = t;
                GridView1.DataBind();
                GridView1.EditIndex = GridView1.Rows.Count - 1;
                GridView1.DataBind();
                Session["MyList"] = t;
            }
        }
    }
