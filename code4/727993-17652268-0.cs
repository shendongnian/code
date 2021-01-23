    protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChckOrdType.Checked = false;
                ChkPlntPric.Checked = false;
                ChkExcluBro.Checked = false;
    
                DisableFirstTime();
                ......
                .....
            }
    private void DisableFirstTime()
    {
      ddlOrdType.Enabled = false; 
      ddlPlntPric.Enabled = false;
      ddlExcluBroker.Enabled = false;  
    }
