    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
          {
              BindStoresList();
              storeDDList.Attributes["onChange"] = "ChangeLabelText();";
          }
    }
