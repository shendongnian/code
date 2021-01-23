    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
           for(int i=1;i<=10;i++)
            {
              var ddl =  FindControl("ddlxx" + i) as DropDownList;
              if (ddl != null)
              {
                BindDropDown(ddl);
              }
            }
        }
    }
    private void BindDropDown(DropDownDataList ddl) 
    {
       ddl.DataSource = Prod.GetValues();
       ddl.DataTextField = "ComponentID";
       ddl.DataValueField = "ComponentName";
       ddl.DataBind();
    }
