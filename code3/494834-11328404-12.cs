    protected void Page_Load(object sender, EventArgs e) 
    {
       if (IsPostBack == false)
       {
          string s = Request.QueryString["cat"];
          string s1 = Request.QueryString["sub"];
          //Still do validation on s and s1
    
          ObjectFactory of = new ObjjectFactory();
          DataGrid1.DataSource = ObjectFactory.GetObjects(s, s1);
          DataGrid1.DataBind();
        }
     }
