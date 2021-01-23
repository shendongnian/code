    protected void Page_Load(object sender, EventArgs e)
    {
       if(!Page.IsPostBack)
         {
          String sqlQuery="select manufacturerid,name From Manufacturertable";
    
          comboBox4.DataSource = cls.Select(sqlQuery);
          comboBox4.DataTextField = "name";
          comboBox4.DataValueField = "manufacturerid";
          comboBox4.DataBind();
       }
     }
