    DBEntities context = new DBEntities();
    private void Form1_Load(object sender, EventArgs e)
    {
      context.MyTable.Where(e => e.myField == 1).Load();
      
      BindingSource bs = new BindingSource();
      bs.DataSource = context.MyTable.Local.ToBindingList();
      myDatagridView.DataSource = bs;
    }
