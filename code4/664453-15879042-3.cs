    protected void Page_Load(object sender, EventArgs e)
    {
    if (!Page.IsPostBack)
    {
      Session["testValue] = dropdownlist1.SelectedItem.text;
    }
    }
