    if(!Page.IsPostBack)
    {
      for (int i = 1; i <= 1000; i++)
      {
        test.Items.Add(new ListItem(i.ToString(), i.ToString()));
      }
    }
