    protected void Page_Load(object sender, EventArgs e)
    {
            if (IsPostBack)
                return;
            
            BindAlphaRepeater();
    }
    
    private void BindAlphaRepeater()
    {
            string[] alphabet = {"a", "b", "c", "d", "e" };
    
            rptAlpha.DataSource = alphabet;
            rptAlpha.DataBind();
    }
    
    protected void rptAlpha_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
            string filterleter = e.CommandArgument as string;
    
            if (filterleter == null)
                return;
    
            ViewState["filterletter"] = filterleter;
    
            GridView1.DataBind();
    }
    
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
            // This is designed to return null, you might want to change it to a default value
            e.InputParameters["Filter"] = ViewState["filterletter"] as string     
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
            Response.Write("Paging click");
            GridView1.DataBind();
    }
