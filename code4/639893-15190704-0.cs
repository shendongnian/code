    ListBox s;
    public FrmDelivery()
    {
      s = new ListBox();
      s.DataSource = new List<int>() { 1, 2, 3, 4 };
      this.Controls.Add(s);
    }
