    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
            GetStatesForDdl(ddl);
    }
     private void GetStatesForDdl(DropDownList ddlStateList)
     {
         AppInputFormProcessor getStates = new AppInputFormProcessor();
         ArrayList States = new ArrayList();
         States = getStates.GetStates();
         ddlStateList.DataSource = States;
         ddlStateList.DataBind();
     }
     
