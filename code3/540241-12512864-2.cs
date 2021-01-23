    protected void Page_Load(object sender, EventArgs e)
    {
       if (!IsPostBack) 
          {
            FillList();
            Viewstate["id"] = Request.QueryString["id"];
             if (Request.QueryString["id"] != null)
               {
                FillData();
                div_General.Visible = true;
                div_Special.Visible = true;
               
               }
          }
    }
