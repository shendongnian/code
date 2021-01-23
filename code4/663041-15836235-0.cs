    protected void Page_Load(object sender, EventArgs e)
    {
      if(!IsPostBack)
      {
            DropDownList3.Items.Clear();
            for (int i = 1920; i <= 2000; i++)
            {
                DropDownList3.Items.Add(i.ToString());
            }
      }
    }
