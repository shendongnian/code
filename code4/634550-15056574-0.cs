    if (!IsPostBack)
    {
      DropDay.Items.Clear();
          for (int i = 1; i <= 10; i++)
          {
              DropDay.Items.Add(i.ToString());
          }
    }
