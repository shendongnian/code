    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        DemoProjServiceClass ob=new DemoProjServiceClass();
        List<DemoProjDomainClass> objList=ob.getDemoProjList();
        if(objList!=null)
        {
           GridView1.DataSource = objList;
           GridView1.DataBind();
        }
       }
    
    }
