    protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    List<string> lst = new List<string>() { "asd", "xxx" };
                    GridView1.DataSource = lst;
                    GridView1.DataBind();
                }
            }
    
    
    
            protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                if (e.CommandName == "MYCOMMAND")
                {
                    Button Button1 = (Button)e.CommandSource;
                    if (Button1 != null)
                        Button1.Text = "changed text..";
                }
            }
