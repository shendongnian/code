    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
         hftestProperty.Value = testProperty.ToString();
      }
    }
