    protected void Page_Init(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        var data = new List<InputDataItem>();
        for (int i = 0; i < 5; i++)
        {
          data.Add(new InputDataItem("Item " + i.ToString()));
        }
        rptInputs.DataSource = data;
        rptInputs.DataBind();
      }
    }
    
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (IsValid)
      {
        var data = new List<InputDataItem>();
        foreach (RepeaterItem rit in rptInputs.Items)
        {
          Control cnt = rit.FindControl("tbxInput");
          if (cnt != null && cnt is TextBox)
            data.Add(new InputDataItem((cnt as TextBox).Text));
        }
        /// here you have list of POCO objects filled with user input
      }
    }
